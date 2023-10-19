# KEFCore: external application

[Entity Framework Core](https://learn.microsoft.com/it-it/ef/core/) provider for [Apache Kafka](https://kafka.apache.org/) shall convert the entities used within the model in something viable from the backend.
Continuing from the concepts introduced in [serialization](serialization.md), an external application can use the data stored in the topics in a way it decides: [Entity Framework Core](https://learn.microsoft.com/it-it/ef/core/) provider for [Apache Kafka](https://kafka.apache.org/) gives some helpers to get back the CLR Entity objects stored in the topics.

> IMPORTANT NOTE: till the first major version, all releases shall be considered not stable: this means the API public, or internal, can change without notice.

## Basic concepts

An external application may want to be informed about data changes in the topics and want to analyze the Entity was previously managed from the EFCore application.
Within the core packages there is the `EntityExtractor` class which contains, till now, few methods and one accepts a raw `ConsumerRecord<byte[], byte[]>` from Apache Kafka.
The method reads the info stored in the `ConsumerRecord<byte[], byte[]>` and returns the Entity object with the filled properties.

It is possible to build a new application which subscribe to a topic created from the EFCore application.
The following is a possible snippet of the logic can be applied:

```c#
const string topicFrom = "TheKEFCoreTopicWithData";

KafkaConsumer<byte[], byte[]> consumer = new KafkaConsumer<byte[], byte[]>();
consumer.Subscribe(topicFrom); // the callback was omitted for simplicity

var records = consumer.Poll(100);

foreach(var record in records)
{
	var entity = EntityExtractor.FromRecord(record);
	Console.WriteLine(entity);
}
```

A full working example can be found under test folder of the [repository](https://github.com/masesgroup/KEFCore).

### Mandatory information

The method `EntityExtractor.FromTopic`, and then `EntityExtractor.FromRecord`, use the reflection to get back the types referring to serializer and types of the model which were stored in the topics.
To work properly it needs, to be loaded in memory, at least:
- The assembly containing the serializer: if the serializer are the default this information is intrisecally available
- The model types (i.e. the types used to build the `DbContext` or `KafkaDbContext`)

## Possible usages

For possible usages of [Entity Framework Core](https://learn.microsoft.com/it-it/ef/core/) provider for [Apache Kafka](https://kafka.apache.org/), and this feature, see [use cases](usecases.md)
