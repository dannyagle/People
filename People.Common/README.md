# People.Common Project
This project contains all interfaces an shared models of the solution.  

In addition, while not the usual case, it also contains the concrete implementations of Resource, Engine, and Manager.  These concrete classes would each normally be housed in the their own projects making them much easier to deploy and scale as services.  However, to keep the code readable, they are kept in the Common project for now.  It would take very little effort to separate them at this point.

## PeopleResource
The resource file is the service responsible for interacting with whatever resources the services need.  Often it will be a database or file system.  In this case it is in charge of loading the the json files and returning freshly minted Person objects back to the caller.

The only services allowed direct access to the resource are the engine and the manager.

## PeopleEngine
The engine is responsible for maintaining business rules, validation, and other special logic needed by other services.

## PeopleManager
The manager is the service layer meant to be exposed to other service layers.  Access to engines and resources must come through a manager.

