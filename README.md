# Sample CRUD Application (COVID Clinic API)

This is a sample API to demonstrate a CRUD Application behavior using .NET Core and CQRS pattern. 


## Technologies
* [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [Entity Framework Core 6](https://docs.microsoft.com/en-us/ef/core/)
* [Duende IdentityServer] (https://github.com/DuendeSoftware/IdentityServer)
* [MediatR](https://github.com/jbogard/MediatR)
* [Mapster](https://github.com/MapsterMapper/Mapster)
* [FluentValidation](https://fluentvalidation.net/)
* [Serilog](https://serilog.net/)
* [Docker](https://www.docker.com/)


### Database Configuration

The template is configured to use an in-memory database by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

If you would like to use SQL Server, you will need to update **WebApi/appsettings.json** as follows:

```json
  "DbProvider": SqlServer
```

`DbProvider` could be `Sqlite`, `SqlServer`, `Npgsql` by default, which could be extended to more database providers that EF Core supports. 

Verify that the **DefaultConnection** connection string within **appsettings.json** points to a valid SQL Server instance.

Verify that the **DefaultConnection_Postgres** connection string within **appsettings.json** points to a valid PostgresSQL instance.

Verify that the **DefaultConnection_Sqlite** connection string within **appsettings.json** points to a valid Sqlite connection or in-memory instance.

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

### Database Migrations

By moving to multiple databases migrations, every db provider will have one migrations project as below.

* `Sqlite`: CovidClinic.Infrastructure.Sqlite
* `SqlServer`: CovidClinic.Infrastructure.SqlServer
* `Npgsql`: CovidClinic.Infrastructure.Npgsql

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### WebApi

This layer is a web api application based on ASP.NET 6.0.x. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.

### How to use

To check any of the endpoints please follow the below steps:

* `Step# 1`: Use the login endpoint and get a Bearer token (User Name: akazad@demo.com, Password: 11!!qqQQ).
* `Step# 2`: Authorize the Swagger UI using the Bearer token
* `Step# 3`: Test your desired API endpoint
