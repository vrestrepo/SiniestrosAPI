Descripción de la solución

Esta solución fue desarrollada como una API REST en .NET 8, siguiendo principios de Arquitectura Limpia, Domain-Driven Design (DDD) y CQRS, con una clara separación de responsabilidades entre capas (Domain, Application, Infrastructure y API). El dominio fue modelado considerando a Accident como Aggregate Root, gestionando internamente la relación many to many con Vehicle mediante la entidad intermedia AccidentVehicle, garantizando invariantes y consistencia del modelo.

Las decisiones arquitectónicas principales se documentaron implícitamente en el diseño del código: uso de CQRS para separar comandos y consultas, repositorios para abstraer persistencia, MediatR como mediador de casos de uso y Entity Framework Core como ORM. Se priorizó un modelo de dominio rico y protegido, evitando lógica de negocio en controladores o infraestructura. La persistencia se implementó inicialmente con InMemoryDatabase para facilitar ejecución y pruebas.

La solución incluye pruebas unitarias enfocadas en el dominio y la capa de aplicación, validando invariantes y casos de uso principales. En caso de extender la solución, el siguiente paso sería completar el read side con consultas optimizadas y proyecciones para filtros y paginación avanzada. La parte que tomó más tiempo fue el modelado correcto de la relación entre accidentes y vehículos respetando DDD y las limitaciones de EF Core.

Tecnologías y herramientas utilizadas: 
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- MediatR (CQRS)
- xUnit, Moq, FluentAssertions
- Swagger / OpenAPI
  
<img width="304" height="348" alt="diagrama siniestros" src="https://github.com/user-attachments/assets/bfd80a27-427b-455a-9abd-f74ea8dfb3cc" />


