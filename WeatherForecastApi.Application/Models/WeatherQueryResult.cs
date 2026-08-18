namespace WeatherForecastApi.Application.Models;

public record class WeatherQueryResult
{
    public required CurrentWeatherQueryResult Current { get; set; }
    public required List<HourlyWeatherQueryResult> Hourly { get; set; }
    public required List<DailyWeatherQueryResult> Daily { get; set; }
}
