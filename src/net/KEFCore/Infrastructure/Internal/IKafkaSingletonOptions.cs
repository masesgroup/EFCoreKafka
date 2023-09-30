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

using MASES.KNet.Common;
using MASES.KNet.Producer;
using MASES.KNet.Streams;

namespace MASES.EntityFrameworkCore.KNet.Infrastructure.Internal;

public interface IKafkaSingletonOptions : ISingletonOptions
{
    bool UseNameMatching { get; }

    string? DatabaseName { get; }

    string? ApplicationId { get; }

    string? BootstrapServers { get; }

    //bool ProducerByEntity { get; }

    bool UseCompactedReplicator { get; }

    bool UsePersistentStorage { get; }

    int DefaultNumPartitions { get; }

    int? DefaultConsumerInstances { get; }

    int DefaultReplicationFactor { get; }

    ProducerConfigBuilder? ProducerConfigBuilder { get; }

    StreamsConfigBuilder? StreamsConfigBuilder { get; }

    TopicConfigBuilder? TopicConfigBuilder { get; }
}
