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

namespace MASES.EntityFrameworkCore.KNet.Storage.Internal;

public interface IKafkaTable : IEntityTypeProducer
{
    IReadOnlyList<object?[]> SnapshotRows();

    IEnumerable<object?[]> Rows { get; }

    IKafkaRowBag Create(IUpdateEntry entry);

    IKafkaRowBag Delete(IUpdateEntry entry);

    IKafkaRowBag Update(IUpdateEntry entry);

    KafkaIntegerValueGenerator<TProperty> GetIntegerValueGenerator<TProperty>(IProperty property, IReadOnlyList<IKafkaTable> tables);

    void BumpValueGenerators(object?[] row);

    IKafkaCluster Cluster { get; }

    IEntityType EntityType { get; }
}
