# Zonda API

A .NET Web API for managing customers and products, designed for deployment to Azure App Service.

---

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Running Locally](#running-locally)
- [Building and Publishing](#building-and-publishing)
- [Deployment to Azure](#deployment-to-azure)
- [API Endpoints](#api-endpoints)
- [Configuration](#configuration)
- [Troubleshooting](#troubleshooting)
- [License](#license)

---

## Project Overview

This project provides a RESTful API for managing customers and products. It is built with ASP.NET Core and Entity Framework Core, and is ready for deployment to Azure App Service.

---

## Features

- CRUD operations for Customers and Products
- Entity Framework Core for data access
- Ready for Azure App Service deployment
- Easily extensible for additional features

---

## Project Structure

```
BackEnd/
  Controllers/         # API controllers for Customers and Products
  Data/                # Entity Framework DbContext
  Models/              # Data models for Customers and Products
  Services/            # Business logic and data services
  Migrations/          # Entity Framework migrations
  Program.cs           # Application entry point
  appsettings.json     # Application configuration
  ZondaAPI.csproj      # Project file
  BackEnd.sln          # Solution file
```

---

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- (Optional) [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli) for deployment

### Setup

1. **Clone the repository:**
   ```sh
   git clone <your-repo-url>
   cd BackEnd
   ```

2. **Restore dependencies:**
   ```sh
   dotnet restore
   ```

3. **Apply database migrations (if using a database):**
   ```sh
   dotnet ef database update
   ```

---

## Running Locally

```sh
dotnet run
```

The API will be available at `http://localhost:5204` (or as specified in your launch settings).

---

## Building and Publishing

### Build

```sh
dotnet build BackEnd.sln --configuration Release
```

### Publish

```sh
dotnet publish ZondaAPI.csproj --configuration Release --output ./publish
```

---

## Deployment to Azure

1. **Create an Azure App Service and a Resource Group (if not already created):**
   ```sh
   az group create --name <ResourceGroupName> --location <Location>
   az appservice plan create --name <AppServicePlan> --resource-group <ResourceGroupName> --sku B1
   az webapp create --name <AppName> --resource-group <ResourceGroupName> --plan <AppServicePlan>
   ```

2. **Deploy using Azure CLI:**
   ```sh
   az webapp deploy --resource-group <ResourceGroupName> --name <AppName> --src-path ./publish
   ```

3. **Make the API public:**
   - Ensure no access restrictions are set in the Azure Portal under Networking > Access Restrictions.
   - Set Authentication to "Off" if you want the API to be public.

---

## API Endpoints

- `GET /api/customers` - List all customers
- `GET /api/customers/{id}` - Get a customer by ID
- `POST /api/customers` - Create a new customer
- `PUT /api/customers/{id}` - Update a customer
- `DELETE /api/customers/{id}` - Delete a customer

- `GET /api/products` - List all products
- `GET /api/products/{id}` - Get a product by ID
- `POST /api/products` - Create a new product
- `PUT /api/products/{id}` - Update a product
- `DELETE /api/products/{id}` - Delete a product

---

## Configuration

- **appsettings.json**: Main configuration file for connection strings and app settings.
- **appsettings.Development.json**: Development-specific settings.

---

## Troubleshooting

- **Build errors about multiple projects:**  
  Specify the `.sln` or `.csproj` file in your `dotnet build` and `dotnet publish` commands.
- **API not accessible:**  
  Check Azure App Service access restrictions and authentication settings.
- **Database issues:**  
  Ensure your connection string is correct and migrations are applied.

---

## License

This project is for interview/testing purposes. Add your license information here if needed.

---
