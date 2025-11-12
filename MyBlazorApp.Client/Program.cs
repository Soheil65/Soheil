using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using MyBlazorApp.Client;
using MyBlazorApp.Client.Services;
using MyBlazorApp.ServerConnector.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HttpClient with base address
var apiUrl = builder.Configuration["ApiUrl"] ?? "https://localhost:7001";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });

// Register application services
builder.Services.AddScoped<IAppStateService, AppStateService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Register ServerConnector services
builder.Services.AddServerConnectors(builder.Configuration);

// Add authorization services (basic for now)
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

await builder.Build().RunAsync();

// Custom AuthenticationStateProvider for demonstration
// In a production app, this would handle JWT tokens properly
public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var anonymous = new System.Security.Claims.ClaimsPrincipal(
            new System.Security.Claims.ClaimsIdentity());
        return Task.FromResult(new AuthenticationState(anonymous));
    }
}
