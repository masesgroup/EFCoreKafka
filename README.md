# KEFCore: [Entity Framework Core](https://learn.microsoft.com/it-it/ef/core/) provider for [Apache Kafka](https://kafka.apache.org/)

KEFCore is the [Entity Framework Core](https://learn.microsoft.com/it-it/ef/core/) provider for [Apache Kafka](https://kafka.apache.org/).
Based on [KNet](https://github.com/masesgroup/KNet) it allows to use [Apache Kafka](https://kafka.apache.org/) as a distributed database and more.

### Libraries and Tools

[![latest version](https://img.shields.io/nuget/v/MASES.EntityFrameworkCore.KNet)](https://www.nuget.org/packages/MASES.EntityFrameworkCore.KNet) [![downloads](https://img.shields.io/nuget/dt/MASES.EntityFrameworkCore.KNet)](https://www.nuget.org/packages/MASES.EntityFrameworkCore.KNet)

### Pipelines

[![CI_BUILD](https://github.com/masesgroup/KEFCore/actions/workflows/build.yaml/badge.svg)](https://github.com/masesgroup/KEFCore/actions/workflows/build.yaml) 
[![CI_RELEASE](https://github.com/masesgroup/KEFCore/actions/workflows/release.yaml/badge.svg)](https://github.com/masesgroup/KEFCore/actions/workflows/release.yaml) 

---

## Scope of the project

This project aims to create a provider to access the information stored within an Apache Kafka cluster using the paradigm behind Entity Framework.
The project is based on available information within the official [EntityFrameworkCore repository](https://github.com/dotnet/efcore), many classes was copied from there as reported in the official documentation within the Microsoft website at https://docs.microsoft.com/en-us/ef/core/providers/writing-a-provider.

### Community and Contribution

Do you like the project? 
- Request your free [community subscription](https://www.jcobridge.com/pricing-25/).

Do you want to help us?
- put a :star: on this project
- open [issues](https://github.com/masesgroup/KEFCore/issues) to request features or report bugs :bug:
- improves the project with Pull Requests

This project adheres to the Contributor [Covenant code of conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to coc_reporting@masesgroup.com.

---

## Summary

* [Getting started](src/documentation/articles/gettingstarted.md)
* [KEFCore usage](src/documentation/articles/usage.md)
* [KEFCore serialization](src/documentation/articles/serialization.md)
* [Roadmap](src/documentation/articles/roadmap.md)
* [Current state](src/documentation/articles/currentstate.md)

---

## Runtime engine

KEFCore uses [KNet](https://github.com/masesgroup/KNet), and indeed [JCOBridge](https://www.jcobridge.com) with its [features](https://www.jcobridge.com/features/), to obtain many benefits:
* **Cyber-security**:
  * [JVM](https://en.wikipedia.org/wiki/Java_virtual_machine) and [CLR, or CoreCLR,](https://en.wikipedia.org/wiki/Common_Language_Runtime) runs in the same process, but are insulated from each other;
  * JCOBridge does not make any code injection into JVM;
  * JCOBridge does not use any other communication mechanism than JNI;
  * .NET (CLR) inherently inherits the cyber-security levels of running JVM and Apache Kafka; 
* **Direct access the JVM from any .NET application**: 
  * Any Java/Scala class behind Apache Kafka can be directly managed: Consumer, Producer, Administration, Streams, Server-side, and so on;
  * No need to learn new APIs: we try to expose the same APIs in C# style;
  * No extra validation cycle on protocol and functionality: bug fix, improvements, new features are immediately available;
  * Documentation is shared.

### JCOBridge resources

Have a look at the following JCOBridge resources:
- [Release notes](https://www.jcobridge.com/release-notes/)
- [Community Edition](https://www.jcobridge.com/pricing-25/)
- [Commercial Edition](https://www.jcobridge.com/pricing-25/)
- Latest release: [![JCOBridge nuget](https://img.shields.io/nuget/v/MASES.JCOBridge)](https://www.nuget.org/packages/MASES.JCOBridge)

---

KAFKA is a registered trademark of The Apache Software Foundation. KEFCore has no affiliation with and is not endorsed by The Apache Software Foundation.
Microsoft is a registered trademark of Microsoft Corporation.
EntityFramework is a registered trademark of Microsoft Corporation.
