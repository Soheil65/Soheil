using MyBlazorApp.ViewModels.ViewModels;

namespace MyBlazorApp.ViewModels.Responses;

public class WeatherForecastResponse
{
    public List<WeatherForecastViewModel>? Forecasts { get; set; }
}
