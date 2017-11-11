# Web API Stateless Projects
These two projects allow the Web API here to run as a stateless Service Fabric application.

The Web API is a ASP.NET Core Web API 2.0 application and requires NetStandard 2.0+.  The main difference between this web project any a non-fabric Web API is the ServiceEventSource.cs and most of the Program.cs.

Assuming you have the SDK installed and Service Fabric running on your machine you can execute the People.Fabric.WebApi project and it will launch the Api.  If you launch the other project you will get an exception.

