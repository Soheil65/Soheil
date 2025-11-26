using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pharmatrack.Client;
using Pharmatrack.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register application services
builder.Services.AddDevExpressBlazor();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Configure HttpClient with API base address
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("https://localhost:7210/") 
});

builder.Services.AddScoped<DxThemesService>();
builder.Services.AddScoped<ApiClientService>();
builder.Services.AddScoped<AppStateService>();
builder.Services.AddScoped<NotificationsService>();
builder.Services.AddScoped<ChatService>();


var app = builder.Build();
await app.RunAsync();