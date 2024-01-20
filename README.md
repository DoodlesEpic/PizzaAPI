# PizzaAPI

PizzaAPI is a simple learning project based on the Microsoft Learn ASP.NET Core Web API modules. This project implements a simple API to store a list of pizzas in a SQLite database. It utilizes ASP.NET Core Web API Controllers for routing, Entity Framework as the ORM, ASP.NET Core Identity for authentication, and Swashbuckle + Swagger UI for API documentation.

Data is stored on a local SQLite database in a file called PizzaAPI.db.

## Development

To develop this project, you will need to first install the .NET SDK.

To start a development build of the project, run:

```bash
dotnet build
```

And to start a development server with hot-reloading of the project, run:

```bash
dotnet watch run
```

You may first need to apply the Entity Framework migrations in the PizzaContext and IdentityContext.

```bash
dotnet ef database update --context PizzaContext
dotnet ef database update --context IdentityContext
```

## Documentation

You may view an interactive OpenAPI documentation on the Swagger UI at [https://localhost:5001/swagger](https://localhost:5001/swagger). Make sure to change the port number to whatever port was chosen for the development server. This is only enabled in development.
