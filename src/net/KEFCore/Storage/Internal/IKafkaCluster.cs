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

using MASES.EntityFrameworkCore.KNet.Infrastructure.Internal;
using MASES.EntityFrameworkCore.KNet.Serdes.Internal;
using MASES.EntityFrameworkCore.KNet.ValueGeneration.Internal;

namespace MASES.EntityFrameworkCore.KNet.Storage.Internal;

public interface IKafkaCluster :IDisposable
{
    bool EnsureDeleted(
        IUpdateAdapterFactory updateAdapterFactory,
        IModel designModel,
        IDiagnosticsLogger<DbLoggerCategory.Update> updateLogger);

    bool EnsureCreated(
        IUpdateAdapterFactory updateAdapterFactory,
        IModel designModel,
        IDiagnosticsLogger<DbLoggerCategory.Update> updateLogger);

    bool EnsureConnected(
        IModel designModel,
        IDiagnosticsLogger<DbLoggerCategory.Update> updateLogger);

    string CreateTable(IEntityType entityType);

    IKafkaSerdesFactory SerdesFactory { get; }

    IEnumerable<ValueBuffer> GetData(IEntityType entityType);

    KafkaIntegerValueGenerator<TProperty> GetIntegerValueGenerator<TProperty>(IProperty property);

    int ExecuteTransaction(
        IList<IUpdateEntry> entries,
        IDiagnosticsLogger<DbLoggerCategory.Update> updateLogger);

    KafkaOptionsExtension Options { get; }
}
