using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlazorApp.ServerConnector.Connectors;

namespace MyBlazorApp.ServerConnector.Configuration;

public static class ServerConnectorExtensions
{
    public static IServiceCollection AddServerConnectors(this IServiceCollection services, IConfiguration configuration)
    {
        var apiUrl = configuration["ApiUrl"] ?? "https://localhost:7001";

        services.AddHttpClient<IWeatherConnector, WeatherConnector>(client =>
        {
            client.BaseAddress = new Uri(apiUrl);
        });

        services.AddHttpClient<IUserConnector, UserConnector>(client =>
        {
            client.BaseAddress = new Uri(apiUrl);
        });

        return services;
    }
}
