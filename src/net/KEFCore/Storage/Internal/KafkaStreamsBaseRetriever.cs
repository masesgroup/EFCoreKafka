﻿/*
*  Copyright 2022 MASES s.r.l.
*
*  Licensed under the Apache License, Version 2.0 (the "License");
*  you may not use this file except in compliance with the License.
*  You may obtain a copy of the License at
*
*  http://www.apache.org/licenses/LICENSE-2.0
*
*  Unless required by applicable law or agreed to in writing, software
*  distributed under the License is distributed on an "AS IS" BASIS,
*  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*  See the License for the specific language governing permissions and
*  limitations under the License.
*
*  Refer to LICENSE for more information.
*/

#nullable enable

using MASES.KNet.Serialization;
using Org.Apache.Kafka.Common.Utils;
using Org.Apache.Kafka.Streams;
using Org.Apache.Kafka.Streams.Errors;
using Org.Apache.Kafka.Streams.Kstream;
using Org.Apache.Kafka.Streams.State;
using static Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler;
using static Org.Apache.Kafka.Streams.KafkaStreams;

namespace MASES.EntityFrameworkCore.KNet.Storage.Internal
{
    public interface IKafkaStreamsBaseRetriever : IEnumerable<ValueBuffer>, IDisposable
    {
    }

    public class KafkaStreamsBaseRetriever<K, V> : IKafkaStreamsBaseRetriever
    {
        private readonly IKafkaCluster _kafkaCluster;
        private readonly IEntityType _entityType;
        private readonly IKNetSerDes<K> _keySerdes;
        private readonly IKNetSerDes<KNetEntityTypeData<K>> _valueSerdes;
        private readonly StreamsBuilder _builder;
        private readonly KStream<K, V> _root;

        private readonly AutoResetEvent dataReceived = new(false);
        private readonly AutoResetEvent resetEvent = new(false);
        private readonly AutoResetEvent stateChanged = new(false);
        private readonly AutoResetEvent exceptionSet = new(false);

        private KafkaStreams? streams = null;
        private StreamsUncaughtExceptionHandler? errorHandler;
        private StateListener? stateListener;

        private readonly string _storageId;
        private Exception? resultException = null;
        private State actualState = State.NOT_RUNNING;
        private ReadOnlyKeyValueStore<K, V>? keyValueStore;

        public KafkaStreamsBaseRetriever(IKafkaCluster kafkaCluster, IEntityType entityType, IKNetSerDes<K> keySerdes, IKNetSerDes<KNetEntityTypeData<K>> valueSerdes, string storageId, StreamsBuilder builder, KStream<K, V> root)
        {
            _kafkaCluster = kafkaCluster;
            _entityType = entityType;
            _keySerdes = keySerdes;
            _valueSerdes = valueSerdes;
            _builder = builder;
            _root = root;
            _storageId = _kafkaCluster.Options.UsePersistentStorage ? storageId : Process.GetCurrentProcess().ProcessName + "-" + storageId;

            StartTopology(_builder, _root);
        }

        private void StartTopology(StreamsBuilder builder, KStream<K, V> root)
        {
            var storeSupplier = _kafkaCluster.Options.UsePersistentStorage ? Stores.PersistentKeyValueStore(_storageId) : Stores.InMemoryKeyValueStore(_storageId);
            var materialized = Materialized<K, V, KeyValueStore<Bytes, byte[]>>.As(storeSupplier);
            root.ToTable(materialized);

            streams = new(builder.Build(), _kafkaCluster.Options.StreamsOptions(_entityType));

            errorHandler = new()
            {
                OnHandle = (exception) =>
                {
                    resultException = exception;
                    exceptionSet.Set();
                    return StreamThreadExceptionResponse.SHUTDOWN_APPLICATION;
                }
            };

            stateListener = new()
            {
                OnOnChange = (newState, oldState) =>
                {
                    actualState = newState;
                    Trace.WriteLine("StateListener oldState: " + oldState + " newState: " + newState + " on " + DateTime.Now.ToString("HH:mm:ss.FFFFFFF"));
                    if (stateChanged != null && !stateChanged.SafeWaitHandle.IsClosed) stateChanged.Set();
                }
            };

            streams.SetUncaughtExceptionHandler(errorHandler);
            streams.SetStateListener(stateListener);

            ThreadPool.QueueUserWorkItem((o) =>
            {
                int waitingTime = Timeout.Infinite;
                Stopwatch watcher = new();
                try
                {
                    resetEvent.Set();
                    var index = WaitHandle.WaitAny(new WaitHandle[] { stateChanged, exceptionSet });
                    if (index == 1) return;
                    while (true)
                    {
                        index = WaitHandle.WaitAny(new WaitHandle[] { stateChanged, dataReceived, exceptionSet }, waitingTime);
                        if (index == 2) return;
                        if (actualState.Equals(State.CREATED) || actualState.Equals(State.REBALANCING))
                        {
                            if (index == WaitHandle.WaitTimeout)
                            {
                                Trace.WriteLine("State: " + actualState + " No handle set within " + waitingTime + " ms");
                                continue;
                            }
                        }
                        else // exit external wait thread 
                        {
                            return;
                        }
                    }
                }
                catch (Exception e)
                {
                    resultException = e;
                }
                finally
                {
                    resetEvent.Set();
                }
            });
            resetEvent.WaitOne();
            streams.Start();
            Trace.WriteLine("Started on " + DateTime.Now.ToString("HH:mm:ss.FFFFFFF"));
            resetEvent.WaitOne(); // wait running state
            if (resultException != null) throw resultException;

            keyValueStore ??= streams?.Store(StoreQueryParameters<ReadOnlyKeyValueStore<K, V>>.FromNameAndType(_storageId, QueryableStoreTypes.KeyValueStore<K, V>()));
        }

        public IEnumerator<ValueBuffer> GetEnumerator()
        {
            if (resultException != null) throw resultException;
            Trace.WriteLine("Requested KafkaEnumerator on " + DateTime.Now.ToString("HH:mm:ss.FFFFFFF"));
            return new KafkaEnumerator(_kafkaCluster, _entityType, _keySerdes, _valueSerdes, keyValueStore);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            streams?.Close();
            dataReceived?.Dispose();
            resetEvent?.Dispose();
            exceptionSet?.Dispose();
            errorHandler?.Dispose();
            stateListener?.Dispose();
            stateChanged?.Dispose();

            streams = null;
            errorHandler = null;
            stateListener = null;
        }

        class KafkaEnumerator : IEnumerator<ValueBuffer>
        {
            private readonly IKafkaCluster _kafkaCluster;
            private readonly IEntityType _entityType;
            private readonly IKNetSerDes<K> _keySerdes;
            private readonly IKNetSerDes<KNetEntityTypeData<K>> _valueSerdes;
            private readonly ReadOnlyKeyValueStore<K, V>? _keyValueStore;
            private KeyValueIterator<K, V>? keyValueIterator = null;
            private IEnumerator<KeyValue<K, V>>? keyValueEnumerator = null;

            public KafkaEnumerator(IKafkaCluster kafkaCluster, IEntityType entityType, IKNetSerDes<K> keySerdes, IKNetSerDes<KNetEntityTypeData<K>> valueSerdes, ReadOnlyKeyValueStore<K, V>? keyValueStore)
            {
                if (kafkaCluster == null) throw new ArgumentNullException(nameof(kafkaCluster));
                if (keySerdes == null) throw new ArgumentNullException(nameof(keySerdes));
                if (valueSerdes == null) throw new ArgumentNullException(nameof(valueSerdes));
                if (keyValueStore == null) throw new ArgumentNullException(nameof(keyValueStore));
                _kafkaCluster = kafkaCluster;
                _entityType = entityType;
                _keySerdes = keySerdes;
                _valueSerdes = valueSerdes;
                _keyValueStore = keyValueStore;
                Trace.WriteLine($"KafkaEnumerator for {_entityType.Name} - ApproximateNumEntries {_keyValueStore?.ApproximateNumEntries()}");
                keyValueIterator = _keyValueStore?.All();
                keyValueEnumerator = keyValueIterator?.ToIEnumerator();
            }

            public ValueBuffer Current
            {
                get
                {
                    if (keyValueEnumerator != null)
                    {
                        var kv = keyValueEnumerator.Current;
                        object? v = kv.value;
                        KNetEntityTypeData<K> entityTypeData = _valueSerdes.DeserializeWithHeaders(null, null, v as byte[]);
                        var data = new ValueBuffer(entityTypeData.GetData(_entityType));
                        if (data.IsEmpty)
                        {
                            throw new InvalidOperationException("Data is Empty");
                        }
                        return data;
                    }
                    throw new InvalidOperationException("InvalidEnumerator");
                }
            }

            object System.Collections.IEnumerator.Current => Current;

            public void Dispose()
            {
                keyValueIterator?.Dispose();
            }

            public bool MoveNext()
            {
                var res = (keyValueEnumerator != null) ? keyValueEnumerator.MoveNext() : false;
                return res;
            }

            public void Reset()
            {
                keyValueIterator?.Dispose();
                keyValueIterator = _keyValueStore?.All();
                keyValueEnumerator = keyValueIterator?.ToIEnumerator();
            }
        }
    }
}