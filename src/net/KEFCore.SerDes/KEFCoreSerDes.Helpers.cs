/*
*  Copyright 2023 MASES s.r.l.
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

using Java.Util;
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Consumer;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Common.Serialization;
using System.Text;

namespace MASES.EntityFrameworkCore.KNet.Serialization;
/// <summary>
/// Stores some fixed names expected from serialization system
/// </summary>
public static class KEFCoreSerDesNames
{
    /// <summary>
    /// Identity the serializer for the key
    /// </summary>
    public const string KeySerializerIdentifier = "key-serializer-type";
    /// <summary>
    /// Identity the serializer for the ValueContainer
    /// </summary>
    public const string ValueContainerSerializerIdentifier = "value-container-serializer-type";
    /// <summary>
    /// Identity the type of the key used
    /// </summary>
    public const string KeyTypeIdentifier = "key-type";
    /// <summary>
    /// Identity the ValueContainer type used
    /// </summary>
    public const string ValueContainerIdentifier = "value-container-type";
    /// <summary>
    /// Returns the typename with the assembly qualification to help reload better the types
    /// </summary>
    /// <param name="type">The <see cref="Type"/> to be converted</param>
    /// <returns>A string with <see cref="Type.FullName"/> along with <see cref="Assembly.FullName"/></returns>
    public static string ToAssemblyQualified(this Type type)
    {
        return $"{type.FullName}, {type.Assembly.GetName().Name}";
    }
}

/// <summary>
/// This is an helper class to extract data information from Kafka Records stored in topics
/// </summary>
public class EntityExtractor
{
    /// <summary>
    /// Extract information for Entity from <paramref name="bootstrapServer"/> within a <paramref name="topicName"/> and send them to <paramref name="cb"/>
    /// </summary>
    /// <param name="bootstrapServer">The Apache Kafka <see href="https://kafka.apache.org/documentation/#consumerconfigs_bootstrap.servers">bootstrap.servers</see></param>
    /// <param name="topicName">The topic containing the data</param>
    /// <param name="cb">The <see cref="Action{T1, T2}"/> where data will be available</param>
    /// <param name="token">The <see cref="CancellationToken"/> to use to stop execution</param>
    /// <param name="onlyLatest">Start execution only for newest messages and does not execute for oldest, default is from beginning</param>
    public static void FromTopic(string bootstrapServer, string topicName, CancellationToken token, Action<object?, Exception?> cb, bool onlyLatest = false)
    {
        FromTopic<object>(bootstrapServer, topicName, token, cb);
    }
    /// <summary>
    /// Extract information for Entity from <paramref name="bootstrapServer"/> within a <paramref name="topicName"/> and send them to <paramref name="cb"/>
    /// </summary>
    /// <typeparam name="TEntity">The Entity type if it is known</typeparam>
    /// <param name="bootstrapServer">The Apache Kafka <see href="https://kafka.apache.org/documentation/#consumerconfigs_bootstrap.servers">bootstrap.servers</see></param>
    /// <param name="topicName">The topic containing the data</param>
    /// <param name="cb">The <see cref="Action{T1, T2}"/> where data will be available</param>
    /// <param name="token">The <see cref="CancellationToken"/> to use to stop execution</param>
    /// <param name="onlyLatest">Start execution only for newest messages and does not execute for oldest, default is from beginning</param>
    public static void FromTopic<TEntity>(string bootstrapServer, string topicName, CancellationToken token, Action<TEntity?, Exception?> cb, bool onlyLatest = false)
        where TEntity : class
    {
        try
        {
            ConsumerConfigBuilder consumerBuilder = ConsumerConfigBuilder.Create()
                                                                         .WithBootstrapServers(bootstrapServer)
                                                                         .WithGroupId(Guid.NewGuid().ToString())
                                                                         .WithAutoOffsetReset(onlyLatest ? ConsumerConfigBuilder.AutoOffsetResetTypes.LATEST : ConsumerConfigBuilder.AutoOffsetResetTypes.EARLIEST)
                                                                         .WithKeyDeserializerClass(JVMBridgeBase.ClassNameOf<ByteArrayDeserializer>())
                                                                         .WithValueDeserializerClass(JVMBridgeBase.ClassNameOf<ByteArrayDeserializer>());

            KafkaConsumer<byte[], byte[]> kafkaConsumer = new KafkaConsumer<byte[], byte[]>(consumerBuilder);
            using var collection = Collections.Singleton(topicName);
            kafkaConsumer.Subscribe(collection);

            while (!token.IsCancellationRequested)
            {
                var records = kafkaConsumer.Poll(100);
                foreach (var record in records)
                {
                    TEntity? entity = null;
                    Exception? exception = null;
                    try
                    {
                        entity = FromRecord<TEntity>(record, true);
                    }
                    catch (Exception ex)
                    {
                        entity = null;
                        exception = ex;
                    }
                    cb.Invoke(entity, exception);
                }
            }
        }
        catch (OperationCanceledException) { return; }
    }

    /// <summary>
    /// Extract information for Entity from <paramref name="record"/> in input
    /// </summary>
    /// <param name="record">The Apache Kafka record containing the information</param>
    /// <param name="throwUnmatch">Throws exceptions if there is unmatch in data retrieve, e.g. a property not available or a not settable</param>
    /// <returns>The extracted entity</returns>
    public static TEntity FromRecord<TEntity>(ConsumerRecord<byte[], byte[]> record, bool throwUnmatch = false)
        where TEntity : class
    {
        return (TEntity)FromRecord(record, throwUnmatch);
    }

    /// <summary>
    /// Extract information for Entity from <paramref name="record"/> in input
    /// </summary>
    /// <param name="record">The Apache Kafka record containing the information</param>
    /// <param name="throwUnmatch">Throws exceptions if there is unmatch in data retrieve, e.g. a property not available or a not settable</param>
    /// <returns>The extracted entity</returns>
    public static object FromRecord(ConsumerRecord<byte[], byte[]> record, bool throwUnmatch = false)
    {
        Type keySerializerType = null;
        Type valueContainerSerializerType = null;
        Type keyType = null;
        Type valueContainerType = null;

        var headers = record.Headers();
        if (headers != null)
        {
            foreach (var header in headers.ToArray())
            {
                var key = header.Key();
                if (key == KEFCoreSerDesNames.KeySerializerIdentifier)
                {
                    var strType = Encoding.UTF8.GetString(header.Value());
                    keySerializerType = Type.GetType(strType, true)!;
                }
                if (key == KEFCoreSerDesNames.ValueContainerSerializerIdentifier)
                {
                    var strType = Encoding.UTF8.GetString(header.Value());
                    valueContainerSerializerType = Type.GetType(strType, true)!;
                }
                if (key == KEFCoreSerDesNames.KeyTypeIdentifier)
                {
                    var strType = Encoding.UTF8.GetString(header.Value());
                    keyType = Type.GetType(strType, true)!;
                }
                if (key == KEFCoreSerDesNames.ValueContainerIdentifier)
                {
                    var strType = Encoding.UTF8.GetString(header.Value());
                    valueContainerType = Type.GetType(strType, true)!;
                }
            }
        }

        return FromRawValueData(keyType!, valueContainerType!, keySerializerType!, valueContainerSerializerType!, record.Topic(), record.Value(), record.Key(), throwUnmatch);
    }

    /// <summary>
    /// Extract information for Entity from <paramref name="recordValue"/> in input
    /// </summary>
    /// <param name="keyType">Expected key <see cref="Type"/></param>
    /// <param name="valueContainer">Expected ValueContainer <see cref="Type"/></param>
    /// <param name="keySerializer">Key serializer to be used</param>
    /// <param name="valueContainerSerializer">ValueContainer serializer to be used</param>
    /// <param name="recordValue">The Apache Kafka record value containing the information</param>
    /// <param name="recordKey">The Apache Kafka record key containing the information</param>
    /// <param name="throwUnmatch">Throws exceptions if there is unmatch in data retrieve, e.g. a property not available or a not settable</param>
    /// <returns>The extracted entity</returns>
    public static object FromRawValueData(Type keyType, Type valueContainer, Type keySerializer, Type valueContainerSerializer, string topic, byte[] recordValue, byte[] recordKey, bool throwUnmatch = false)
    {
        var fullKeySerializer = keySerializer.MakeGenericType(keyType);
        var fullValueContainer = valueContainer.MakeGenericType(keyType);
        var fullValueContainerSerializer = valueContainerSerializer.MakeGenericType(fullValueContainer);

        var ccType = typeof(LocalEntityExtractor<,,,>);
        var extractorType = ccType.MakeGenericType(keyType, fullValueContainer, fullKeySerializer, fullValueContainerSerializer);
        var extractor = Activator.CreateInstance(extractorType) as ILocalEntityExtractor;

        return extractor!.GetEntity(topic, recordValue, recordKey, throwUnmatch);
    }
}