# Pharmatrack - Pharmacy Management System

A modern Blazor WebAssembly application built with .NET 9, following Clean Architecture principles.

## 🏗️ Architecture

This solution follows Clean Architecture with clear separation of concerns:

```
Pharmatrack/
├── Pharmatrack.ViewModels          # DTOs and Shared Models
├── Pharmatrack.Client.ServerConnector  # API Communication Layer
├── Pharmatrack.API                 # ASP.NET Core Web API Backend
├── Pharmatrack.Client              # Blazor WebAssembly Frontend
└── Pharmatrack.Client.Test         # bUnit/xUnit Tests
```

## 📋 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- IDE of your choice (Visual Studio 2022, VS Code, or Rider)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/Soheil65/Soheil.git
cd Soheil
```

### 2. Build the Solution

```bash
dotnet build Pharmatrack.sln
```

### 3. Run the Application

You need to run both the API and the Client:

#### Terminal 1 - Start the API

```bash
cd Pharmatrack.API
dotnet run
```

The API will be available at:
- HTTPS: https://localhost:7210
- HTTP: http://localhost:5071
- API Documentation: https://localhost:7210/scalar/v1

#### Terminal 2 - Start the Client

```bash
cd Pharmatrack.Client
dotnet run
```

The client will be available at:
- HTTPS: https://localhost:7098
- HTTP: http://localhost:5014

### 4. Run Tests

```bash
dotnet test Pharmatrack.sln
```

## 📦 Project Details

### Pharmatrack.ViewModels

Contains shared DTOs and ViewModels:
- `ProductViewModel` - Product display model
- `ProductRequest` - Product creation/update request
- `BaseResponse<T>` - Generic API response wrapper
- `PaginationModel` - Pagination metadata

### Pharmatrack.Client.ServerConnector

API communication layer:
- `ApiConnector` - Generic HTTP operations
- `ProductEndpoint` - Product-specific API calls
- `ApiRoutes` - Centralized API route definitions
- `HttpExtensions` - HTTP helper methods

### Pharmatrack.API

ASP.NET Core Web API:
- `ProductController` - RESTful product endpoints
- `ProductService` - Business logic layer
- `ApplicationDbContext` - In-memory data store
- OpenAPI documentation with Scalar UI
- CORS configured for Blazor client

**API Endpoints:**
- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create new product
- `PUT /api/products/{id}` - Update product
- `DELETE /api/products/{id}` - Delete product

### Pharmatrack.Client

Blazor WebAssembly frontend:

**Pages:**
- Home (`/`) - Landing page with feature cards
- About (`/about`) - Information about the system
- Products (`/products`) - Product listing page

**Shared Components:**
- `Header` - Application header
- `Footer` - Application footer
- `NavMenu` - Navigation sidebar

**Layouts:**
- `MainLayout` - Main application layout with header, sidebar, content, and footer

**Services:**
- `ApiClientService` - Wraps API connector for easy DI
- `AppStateService` - Global state management

### Pharmatrack.Client.Test

bUnit and xUnit tests:
- Component tests for all shared components
- Page tests for home page
- Test fixtures for reusable test setup

## 🎨 Features

- ✅ Clean Architecture with clear separation of concerns
- ✅ RESTful API with OpenAPI documentation
- ✅ Modern UI with Bootstrap 5
- ✅ Responsive design
- ✅ Comprehensive unit tests
- ✅ Dependency Injection throughout
- ✅ CORS configuration for secure cross-origin requests
- ✅ In-memory data store with seed data

## 🔧 Configuration

### API Configuration

The API is configured in `Pharmatrack.API/Program.cs`:
- CORS allows requests from the Blazor client
- JSON serialization preserves property name casing
- OpenAPI documentation with Scalar UI

### Client Configuration

The client is configured in `Pharmatrack.Client/Program.cs`:
- HttpClient base address points to API
- Services registered for dependency injection

## 📝 Development

### Adding a New Page

1. Create a new folder under `Pharmatrack.Client/Pages/`
2. Add your `.razor` file
3. Add route with `@page "/your-route"`
4. Add navigation link in `NavMenu.razor`

### Adding a New API Endpoint

1. Add ViewModel/Request classes in `Pharmatrack.ViewModels`
2. Create endpoint class in `Pharmatrack.Client.ServerConnector/Endpoints`
3. Add controller method in `Pharmatrack.API/Controllers`
4. Add service method in `Pharmatrack.API/Services`

### Adding Tests

1. Create test class in appropriate folder under `Pharmatrack.Client.Test`
2. Use `BunitContext` for component rendering
3. Follow AAA pattern (Arrange, Act, Assert)

## 🧪 Testing

The solution includes comprehensive tests using bUnit and xUnit:

```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --logger "console;verbosity=detailed"

# Run tests for a specific project
dotnet test Pharmatrack.Client.Test/Pharmatrack.Client.Test.csproj
```

Current test coverage:
- ✅ 11 tests, 0 failures
- Header component tests
- Footer component tests
- NavMenu component tests
- Home page tests

## 🛠️ Built With

- [.NET 9](https://dotnet.microsoft.com/download/dotnet/9.0) - Framework
- [Blazor WebAssembly](https://docs.microsoft.com/en-us/aspnet/core/blazor/) - Frontend
- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/) - Backend
- [bUnit](https://bunit.dev/) - Blazor component testing
- [xUnit](https://xunit.net/) - Testing framework
- [Bootstrap 5](https://getbootstrap.com/) - UI framework
- [Scalar](https://github.com/scalar/scalar) - API documentation UI

## 📄 License

This project is part of the Soheil repository.

## 👥 Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## 📧 Contact

For questions or support, please open an issue in the repository.
