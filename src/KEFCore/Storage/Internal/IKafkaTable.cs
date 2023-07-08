/*
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

using MASES.EntityFrameworkCore.KNet.ValueGeneration.Internal;
using Java.Util.Concurrent;
using Org.Apache.Kafka.Clients.Producer;
using MASES.KNet.Producer;

namespace MASES.EntityFrameworkCore.KNet.Storage.Internal;

public interface IKafkaTable
{
    IReadOnlyList<object?[]> SnapshotRows();

    IEnumerable<ValueBuffer> ValueBuffers { get; }

    IEnumerable<object?[]> Rows { get; }

    KNetProducerRecord<string, string> Create(IUpdateEntry entry);

    KNetProducerRecord<string, string> Delete(IUpdateEntry entry);

    KNetProducerRecord<string, string> Update(IUpdateEntry entry);

    IEnumerable<Future<RecordMetadata>> Commit(IEnumerable<KNetProducerRecord<string, string>> records);

    KafkaIntegerValueGenerator<TProperty> GetIntegerValueGenerator<TProperty>(
        IProperty property,
        IReadOnlyList<IKafkaTable> tables);

    void BumpValueGenerators(object?[] row);

    IKafkaCluster Cluster { get; }

    IEntityType EntityType { get; }
}
