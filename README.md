# dotnetcore onion architecture


![onion](https://github.com/Krishnaprasadk03/dotnet-core-onion-architecture/assets/29447412/962addc4-a714-4035-914c-f7a15192a565)

The Onion Architecture promotes a modular and loosely coupled design that focuses on separation of concerns and maintainability. It helps to create applications with a clear separation between the core domain logic and the infrastructure layers.
   # Domain Layer: 
    This layer contains the core business logic, entities,enum, and rules of the application, representing the fundamental concepts and behaviors.

   # Application (AL): 
    This layer implements the use cases and orchestrates the interactions between the domain and infrastructure layers,
    providing specific application logic and workflows.

   # Infrastructure (IL): 
   This layer handles the technical details and external concerns, such as data access, services, and frameworks, 
   supporting the application's infrastructure needs.

   # Presentation (PL): 
    This layer focuses on the user interface and user interaction aspects, enabling the presentation and visualization of information to users,
    often through web, mobile, or desktop interfaces.

# Technologies Used:

  -  .Net 7
  -  Entity Framework
  -  NLog
  -  Swagger

