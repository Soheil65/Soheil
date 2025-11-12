using MyBlazorApp.ViewModels.Responses;
using MyBlazorApp.ViewModels.ViewModels;

namespace MyBlazorApp.ServerConnector.Connectors;

public class WeatherConnector : BaseConnector, IWeatherConnector
{
    public WeatherConnector(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<ApiResponse<List<WeatherForecastViewModel>>> GetWeatherForecastAsync()
    {
        return await GetAsync<List<WeatherForecastViewModel>>("api/weatherforecast");
    }
}
