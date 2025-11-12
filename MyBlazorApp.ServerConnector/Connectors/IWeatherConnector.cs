using MyBlazorApp.ViewModels.Responses;
using MyBlazorApp.ViewModels.ViewModels;

namespace MyBlazorApp.ServerConnector.Connectors;

public interface IWeatherConnector
{
    Task<ApiResponse<List<WeatherForecastViewModel>>> GetWeatherForecastAsync();
}
