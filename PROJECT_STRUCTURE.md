# Pharmatrack Solution Structure

## 📁 Complete Project Structure

```
Pharmatrack/
│
├── 📄 Pharmatrack.sln                          # Solution file
├── 📄 README_PHARMATRACK.md                    # Comprehensive documentation
│
├── 📁 Pharmatrack.ViewModels/                  # DTOs & Shared Models
│   ├── Products/
│   │   ├── ProductViewModel.cs                # Product display model
│   │   └── ProductRequest.cs                  # Product create/update model
│   └── Shared/
│       ├── BaseResponse.cs                    # Generic API response wrapper
│       └── PaginationModel.cs                 # Pagination metadata
│
├── 📁 Pharmatrack.Client.ServerConnector/      # API Communication Layer
│   ├── ApiConnector.cs                        # Generic HTTP operations
│   ├── Endpoints/
│   │   └── ProductEndpoint.cs                # Product API calls
│   └── Helpers/
│       ├── ApiRoutes.cs                       # Centralized route definitions
│       └── HttpExtensions.cs                  # HTTP helper methods
│
├── 📁 Pharmatrack.API/                         # ASP.NET Core Web API Backend
│   ├── Controllers/
│   │   └── ProductController.cs              # RESTful product endpoints
│   ├── Services/
│   │   └── ProductService.cs                 # Business logic layer
│   ├── Models/
│   │   └── DbProduct.cs                      # Database product model
│   ├── Data/
│   │   └── ApplicationDbContext.cs           # In-memory data context
│   ├── Program.cs                            # API startup & configuration
│   ├── appsettings.json                      # Configuration settings
│   └── Properties/
│       └── launchSettings.json               # Launch profiles
│
├── 📁 Pharmatrack.Client/                      # Blazor WebAssembly Frontend
│   ├── App.razor                             # App component with routing
│   ├── Program.cs                            # Client startup & DI config
│   ├── _Imports.razor                        # Global Razor imports
│   │
│   ├── Pages/                                # Application Pages
│   │   ├── Home/
│   │   │   └── Home.razor                    # Landing page (/)
│   │   ├── About/
│   │   │   └── About.razor                   # About page (/about)
│   │   └── Products/
│   │       └── Products.razor                # Products page (/products)
│   │
│   ├── SharedComponents/                     # Reusable Components
│   │   ├── Header.razor                      # Application header
│   │   ├── Footer.razor                      # Application footer
│   │   └── NavMenu.razor                     # Navigation sidebar
│   │
│   ├── Layouts/                              # Layout Components
│   │   └── MainLayout.razor                  # Main layout structure
│   │
│   ├── Services/                             # Client Services
│   │   ├── ApiClientService.cs               # API client wrapper
│   │   └── AppStateService.cs                # Global state management
│   │
│   └── wwwroot/                              # Static assets
│       ├── index.html                        # HTML host page
│       ├── css/                              # Stylesheets
│       └── lib/bootstrap/                    # Bootstrap 5 library
│
└── 📁 Pharmatrack.Client.Test/                # bUnit/xUnit Tests
    ├── Usings.cs                             # Global test imports
    ├── TestFixtures/
    │   └── TestContextFactory.cs             # Reusable test setup
    ├── Pages/
    │   └── HomeTests.cs                      # Home page tests
    └── SharedComponents/
        ├── HeaderTests.cs                    # Header component tests
        ├── FooterTests.cs                    # Footer component tests
        └── NavMenuTests.cs                   # NavMenu component tests
```

## 🔗 Project Dependencies

```
Pharmatrack.Client
    ├── → Pharmatrack.Client.ServerConnector
    └── → Pharmatrack.ViewModels

Pharmatrack.Client.ServerConnector
    └── → Pharmatrack.ViewModels

Pharmatrack.API
    └── → Pharmatrack.ViewModels

Pharmatrack.Client.Test
    └── → Pharmatrack.Client
```

## 🎯 Key Features

### Backend (API)
- ✅ RESTful endpoints for products (GET, POST, PUT, DELETE)
- ✅ In-memory data store with seed data
- ✅ OpenAPI specification with Scalar UI
- ✅ CORS configured for cross-origin requests
- ✅ Dependency Injection
- ✅ Clean Architecture

### Frontend (Client)
- ✅ Blazor WebAssembly with .NET 9
- ✅ Responsive layout with Bootstrap 5
- ✅ Component-based architecture
- ✅ Typed API communication
- ✅ State management
- ✅ Navigation system

### Testing
- ✅ Component tests with bUnit
- ✅ Unit tests with xUnit
- ✅ 11 passing tests
- ✅ Test fixtures for reusability

## 🚀 Running the Application

### Start API (Terminal 1)
```bash
cd Pharmatrack.API
dotnet run
# API: https://localhost:7210
# Docs: https://localhost:7210/scalar/v1
```

### Start Client (Terminal 2)
```bash
cd Pharmatrack.Client
dotnet run
# Client: https://localhost:7098
```

### Run Tests
```bash
dotnet test Pharmatrack.sln
```

## 📊 Statistics

- **Total Projects**: 5
- **Total C# Files**: 23
- **Total Razor Files**: 8
- **Total Tests**: 11 (all passing)
- **Target Framework**: .NET 9.0
- **Architecture**: Clean Architecture
- **UI Framework**: Bootstrap 5
- **API Documentation**: OpenAPI with Scalar UI
