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

using MASES.KNet.Common;
using MASES.KNet.Producer;
using MASES.KNet.Streams;

namespace MASES.EntityFrameworkCore.KNet.Infrastructure;

/// <summary>
///     A <see cref="KafkaDbContext"/> instance represents a session with the Apache Kafka cluster and can be used to query and save
///     instances of your entities. <see cref="KafkaDbContext"/> extends <see cref="DbContext"/> and it is a combination of the Unit Of Work and Repository patterns.
/// </summary>
/// <remarks>
///     <para>
///         Entity Framework Core does not support multiple parallel operations being run on the same <see cref="KafkaDbContext"/> instance. This
///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see> for more information
///         and examples.
///     </para>
///     <para>
///         Typically you create a class that derives from DbContext and contains <see cref="DbSet{TEntity}" />
///         properties for each entity in the model. If the <see cref="DbSet{TEntity}" /> properties have a public setter,
///         they are automatically initialized when the instance of the derived context is created.
///     </para>
///     <para>
///         Typically you don't need to override the <see cref="OnConfiguring(DbContextOptionsBuilder)" /> method to configure the database (and
///         other options) to be used for the context, just set the properties associated to <see cref="KafkaDbContext"/> class.
///         Alternatively, if you would rather perform configuration externally instead of inline in your context, you can use <see cref="DbContextOptionsBuilder{TContext}" />
///         (or <see cref="DbContextOptionsBuilder" />) to externally create an instance of <see cref="DbContextOptions{TContext}" />
///         (or <see cref="DbContextOptions" />) and pass it to a base constructor of <see cref="DbContext" />.
///     </para>
///     <para>
///         The model is discovered by running a set of conventions over the entity classes found in the
///         <see cref="DbSet{TEntity}" /> properties on the derived context. To further configure the model that
///         is discovered by convention, you can override the <see cref="DbContext.OnModelCreating(ModelBuilder)" /> method.
///     </para>
///     <para>
///         See <see href="https://masesgroup.github.io/KEFCore/articles/kafkadbcontext.html">KafkaDbContext configuration and initialization</see>,
///         <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>,
///         <see href="https://aka.ms/efcore-docs-query">Querying data with EF Core</see>,
///         <see href="https://aka.ms/efcore-docs-change-tracking">Changing tracking</see>, and
///         <see href="https://aka.ms/efcore-docs-saving-data">Saving data with EF Core</see> for more information and examples.
///     </para>
/// </remarks>
public class KafkaDbContext : DbContext
{
#if DEBUG_PERFORMANCE
    const bool perf = true;
    /// <summary>
    /// Enable tracing of <see cref="MASES.EntityFrameworkCore.KNet.Storage.Internal.EntityTypeDataStorage{TKey}"/>
    /// </summary>
    public static bool TraceEntityTypeDataStorageGetData = false;

    public static void ReportString(string message)
    {
        if (!_enableKEFCoreTracing) return;

        if (Debugger.IsAttached)
        {
            Trace.WriteLine($"{DateTime.Now:HH::mm::ss:ffff} - {message}");
        }
        else
        {
            Console.WriteLine($"{DateTime.Now:HH::mm::ss:ffff} - {message}");
        }
    }
#else
const bool perf = false;
#endif
    /// <summary>
    /// Reports if the library was compiled to reports performance information
    /// </summary>
    public const bool IsPerformanceVersion = perf;
    static bool _enableKEFCoreTracing = false;
    /// <summary>
    /// Set to <see langword="true"/> to enable tracing of KEFCore
    /// </summary>
    /// <remarks>Can be set only if the project is compiled with DEBUG_PERFORMANCE preprocessor directive, otherwise an <see cref="InvalidOperationException"/> is raised</remarks>
    public static bool EnableKEFCoreTracing
    {
        get { return _enableKEFCoreTracing; }
        set 
        {
            _enableKEFCoreTracing = value;
#if DEBUG_PERFORMANCE
            if (_enableKEFCoreTracing) throw new InvalidOperationException("Compile KEFCore using DEBUG_PERFORMANCE preprocessor directive");
#endif
        }
    }

    /// <inheritdoc cref="DbContext.DbContext()"/>
    public KafkaDbContext()
    {

    }
    /// <inheritdoc cref="DbContext.DbContext(DbContextOptions)"/>
    public KafkaDbContext(DbContextOptions options) : base(options)
    {

    }

    /// <summary>
    /// The bootstrap servers of the Apache Kafka cluster
    /// </summary>
    public virtual string? BootstrapServers { get; set; }
    /// <summary>
    /// The application id
    /// </summary>
    public virtual string ApplicationId { get; set; } = Guid.NewGuid().ToString();
    /// <summary>
    /// Database name
    /// </summary>
    public virtual string? DbName { get; set; }
    /// <summary>
    /// Default number of partitions associated to each topic
    /// </summary>
    public virtual int DefaultNumPartitions { get; set; } = 10;
    /// <summary>
    /// Default replication factor associated to each topic
    /// </summary>
    public virtual short DefaultReplicationFactor { get; set; } = 1;
    /// <summary>
    /// Default consumr instances used in conjunction with <see cref="UseCompactedReplicator"/>
    /// </summary>
    public virtual int? DefaultConsumerInstances { get; set; } = null;
    /// <summary>
    /// Use persistent storage when Apache Kafka Streams is in use
    /// </summary>
    public virtual bool UsePersistentStorage { get; set; } = false;
    ///// <summary>
    ///// Use a producer for each Entity
    ///// </summary>
    //public bool UseProducerByEntity { get; set; } = false;
    /// <summary>
    /// Use <see cref="MASES.KNet.Replicator.KNetCompactedReplicator{TKey, TValue}"/> instead of Apache Kafka Streams
    /// </summary>
    public virtual bool UseCompactedReplicator { get; set; } = false;
    /// <summary>
    /// The optional <see cref="ProducerConfigBuilder"/>
    /// </summary>
    public virtual ProducerConfigBuilder? ProducerConfigBuilder { get; set; }
    /// <summary>
    /// The optional <see cref="StreamsConfigBuilder"/>
    /// </summary>
    public virtual StreamsConfigBuilder? StreamsConfigBuilder { get; set; }
    /// <summary>
    /// The optional <see cref="TopicConfigBuilder"/>
    /// </summary>
    public virtual TopicConfigBuilder? TopicConfigBuilder { get; set; }
    /// <inheritdoc cref="DbContext.OnConfiguring(DbContextOptionsBuilder)"/>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (BootstrapServers == null) throw new ArgumentNullException(nameof(BootstrapServers));
        if (DbName == null) throw new ArgumentNullException(nameof(DbName));

        optionsBuilder.UseKafkaCluster(ApplicationId, DbName, BootstrapServers, (o) =>
        {
            o.StreamsConfig(StreamsConfigBuilder ?? o.EmptyStreamsConfigBuilder).WithDefaultNumPartitions(DefaultNumPartitions);
            o.WithUsePersistentStorage(UsePersistentStorage);
            //o.WithProducerByEntity(UseProducerByEntity);
            o.WithCompactedReplicator(UseCompactedReplicator);
            o.WithDefaultReplicationFactor(DefaultReplicationFactor);
        });
    }
}
