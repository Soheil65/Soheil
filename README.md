# MyBlazorApp - Blazor WebAssembly with JWT Authentication and Clean Architecture

A complete Blazor WebAssembly application demonstrating clean architecture principles, JWT-based authentication, and best practices for modern web development with .NET 9.

## 📋 Overview

This solution showcases a production-ready Blazor WebAssembly application with:
- **Clean Architecture** with clear separation of concerns
- **JWT Bearer Authentication** for secure API access
- **ASP.NET Core Identity** for user management
- **RESTful API** backend with documented endpoints
- **Blazor WebAssembly** frontend with component-based architecture
- **Shared ViewModels** for type-safe data transfer
- **Dependency Injection** throughout all layers
- **In-Memory Database** for development and testing

## 🏗️ Solution Structure

The solution consists of four projects:

### 1. **MyBlazorApp.Client** (Blazor WebAssembly)
The frontend application that runs in the browser.

```
MyBlazorApp.Client/
├── Pages/                      # Page components organized by feature
│   ├── Home/
│   │   └── Home.razor         # Home page
│   ├── Counter/
│   │   └── Counter.razor      # Interactive counter demo
│   ├── FetchData/
│   │   └── FetchData.razor    # Demonstrates API data fetching
│   └── Authentication/
│       ├── Login.razor         # User login page
│       ├── Logout.razor        # Logout handler
│       └── Profile.razor       # User profile management
├── SharedComponents/          # Reusable components
│   ├── NavMenu.razor          # Navigation menu
│   ├── MainLayout.razor       # Main layout template
│   ├── LoadingSpinner.razor   # Loading indicator
│   └── ErrorBoundary.razor    # Error handling component
├── Models/                    # Client-side models
│   ├── WeatherForecast.cs
│   └── UserProfile.cs
├── Services/                  # Client services
│   ├── IAppStateService.cs
│   ├── AppStateService.cs     # Global application state
│   ├── IAuthService.cs
│   └── AuthService.cs         # Authentication state management
└── wwwroot/
    └── appsettings.json       # Client configuration
```

### 2. **MyBlazorApp.Server** (ASP.NET Core Web API)
The backend API with authentication and business logic.

```
MyBlazorApp.Server/
├── Controllers/               # API endpoints
│   ├── AuthController.cs      # Authentication (login, JWT generation)
│   ├── WeatherForecastController.cs  # Weather data API
│   └── UserController.cs      # User profile management
├── Models/                    # Server-side models
│   ├── ApplicationUser.cs     # User entity
│   └── ApplicationDbContext.cs # EF Core DbContext
├── Configuration/
│   └── JwtSettings.cs         # JWT configuration
├── Program.cs                 # Application startup and configuration
└── appsettings.json           # Server configuration
```

### 3. **MyBlazorApp.ServerConnector** (Class Library)
Handles all HTTP communication between client and server.

```
MyBlazorApp.ServerConnector/
├── Connectors/
│   ├── BaseConnector.cs       # Base class with HttpClient
│   ├── IWeatherConnector.cs   # Weather API interface
│   ├── WeatherConnector.cs    # Weather API implementation
│   ├── IUserConnector.cs      # User API interface
│   └── UserConnector.cs       # User API implementation
└── Configuration/
    └── ServerConnectorExtensions.cs  # DI registration helpers
```

### 4. **MyBlazorApp.ViewModels** (Class Library)
Shared data models used across all projects.

```
MyBlazorApp.ViewModels/
├── ViewModels/
│   ├── WeatherForecastViewModel.cs
│   └── UserProfileViewModel.cs
├── Requests/
│   ├── LoginRequest.cs
│   └── UpdateProfileRequest.cs
└── Responses/
    ├── ApiResponse.cs         # Generic API response wrapper
    ├── WeatherForecastResponse.cs
    └── UserProfileResponse.cs
```

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- A code editor (Visual Studio 2022, Visual Studio Code, or Rider)

### Installation & Running

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd Soheil
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore MyBlazorApp.sln
   ```

3. **Build the solution**
   ```bash
   dotnet build MyBlazorApp.sln
   ```

4. **Run the Server API**
   
   Open a terminal and run:
   ```bash
   cd MyBlazorApp.Server
   dotnet run
   ```
   
   The API will start at `https://localhost:7001` (or `http://localhost:5000`)

5. **Run the Client Application**
   
   Open another terminal and run:
   ```bash
   cd MyBlazorApp.Client
   dotnet run
   ```
   
   The client will start at `https://localhost:5001` (or `http://localhost:5000`)

6. **Open in Browser**
   
   Navigate to `https://localhost:5001` (or the URL shown in your terminal)

### Demo Credentials

A default user is seeded in the database for testing:
- **Username:** demo
- **Password:** Demo123!

## 🔐 Authentication Flow

1. User enters credentials on the login page
2. Client sends credentials to `/api/auth/login` endpoint
3. Server validates credentials using ASP.NET Core Identity
4. Server generates a JWT token with user claims
5. Client stores the token (in a real app, this would be in local storage or a cookie)
6. Client includes the token in the Authorization header for subsequent API requests
7. Server validates the JWT token for protected endpoints

## 🔑 Key Features

### Clean Architecture Benefits

- **Separation of Concerns**: Each project has a clear responsibility
- **Testability**: Business logic can be tested independently
- **Maintainability**: Changes to one layer don't affect others
- **Scalability**: Easy to add new features without breaking existing code

### Authentication & Security

- JWT Bearer tokens for stateless authentication
- Password hashing with ASP.NET Core Identity
- CORS configuration for client-server communication
- Authorization attributes on protected endpoints

### Best Practices Implemented

1. **Dependency Injection**
   - All services registered with appropriate lifetimes
   - Constructor injection throughout the application

2. **Error Handling**
   - Try-catch blocks in connectors
   - ApiResponse wrapper for consistent error messaging
   - Error boundary component in the client

3. **State Management**
   - AppStateService for global application state
   - AuthenticationStateProvider for auth state

4. **Code Organization**
   - One component per file
   - Related components grouped in folders
   - Interfaces for all services and connectors

## 📚 API Endpoints

### Authentication
- `POST /api/auth/login` - Authenticate user and receive JWT token

### Weather Forecast
- `GET /api/weatherforecast` - Get weather forecast data

### User Profile
- `GET /api/user/profile` - Get current user's profile (requires authentication)
- `PUT /api/user/profile` - Update current user's profile (requires authentication)

## 🛠️ Development

### Adding a New API Endpoint

1. **Create ViewModel in MyBlazorApp.ViewModels**
   ```csharp
   public class MyViewModel { ... }
   ```

2. **Create Controller in MyBlazorApp.Server**
   ```csharp
   [ApiController]
   [Route("api/[controller]")]
   public class MyController : ControllerBase { ... }
   ```

3. **Create Connector in MyBlazorApp.ServerConnector**
   ```csharp
   public interface IMyConnector { ... }
   public class MyConnector : BaseConnector, IMyConnector { ... }
   ```

4. **Register in ServerConnectorExtensions**
   ```csharp
   services.AddHttpClient<IMyConnector, MyConnector>(...);
   ```

5. **Use in Blazor Component**
   ```razor
   @inject IMyConnector MyConnector
   ```

### Project Dependencies

```
MyBlazorApp.Client
  ↓ references
  ├── MyBlazorApp.ServerConnector
  │     ↓ references
  │     └── MyBlazorApp.ViewModels
  └── MyBlazorApp.ViewModels

MyBlazorApp.Server
  ↓ references
  └── MyBlazorApp.ViewModels
```

## 📦 NuGet Packages

### Client
- Microsoft.AspNetCore.Components.WebAssembly
- Microsoft.AspNetCore.Components.WebAssembly.Authentication
- Microsoft.AspNetCore.Components.Authorization
- Microsoft.Extensions.Http

### Server
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.InMemory

### ServerConnector
- System.Net.Http.Json
- Microsoft.Extensions.Http
- Microsoft.Extensions.DependencyInjection.Abstractions
- Microsoft.Extensions.Configuration.Abstractions

## 🧪 Testing

To run tests (when implemented):
```bash
dotnet test MyBlazorApp.sln
```

## 📝 Configuration

### Client Configuration (`wwwroot/appsettings.json`)
```json
{
  "ApiUrl": "https://localhost:7001"
}
```

### Server Configuration (`appsettings.json`)
```json
{
  "JwtSettings": {
    "SecretKey": "your-secret-key-here",
    "Issuer": "https://localhost:7001",
    "Audience": "https://localhost:5001",
    "ExpirationInMinutes": 60
  }
}
```

## 🚧 Future Enhancements

- [ ] Implement refresh tokens for long-lived sessions
- [ ] Add user registration functionality
- [ ] Implement persistent storage (replace in-memory database)
- [ ] Add unit and integration tests
- [ ] Implement comprehensive logging
- [ ] Add role-based authorization
- [ ] Create Docker containers for deployment
- [ ] Add API documentation with Swagger/OpenAPI
- [ ] Implement email confirmation
- [ ] Add two-factor authentication

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📄 License

This project is provided as-is for educational and demonstration purposes.

## 👥 Authors

- Initial implementation following clean architecture principles

## 🙏 Acknowledgments

- Microsoft for the excellent Blazor and ASP.NET Core frameworks
- The .NET community for best practices and patterns
