# bndlstore-services-poc

This repository contains a proof-of-concept for a modular .NET 8 microservices architecture, including Catalog and Basket services.

## Technologies Used

- .NET 8 (C# 12)
- ASP.NET Core Minimal APIs
- Carter (minimal API routing)
- MediatR (CQRS and mediator pattern)
- Marten (PostgreSQL document DB)
- Docker & Docker Compose
- Health Checks

## Services

- **CatalogAPI**: Product catalog service with CQRS, validation, logging, and health checks.
- **BasketAPI**: Shopping basket service.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)

### Running with Docker

1. Build and start services:
   ```
   docker-compose up --build
   ```
2. CatalogDB (PostgreSQL) will be available at `localhost:5432`.

### Configuration

- Connection strings and environment variables are managed in `docker-compose.override.yml` and `appsettings.json`.
- CatalogAPI uses HTTPS by default.

### Health Checks

- Access health checks at: `https://localhost:<CatalogAPI_Port>/health`

## Project Structure

```
Services/
  Catalog/
    CatalogAPI/
  Basket/
    BasketAPI/
docker-compose.yml
docker-compose.override.yml
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first.

## License

This project is licensed under the MIT License.
