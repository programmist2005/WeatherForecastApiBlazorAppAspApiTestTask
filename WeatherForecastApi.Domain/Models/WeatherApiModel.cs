namespace WeatherForecastApi.Domain.Models;

public record class WeatherApiModel
{
    public required LocationApiModel Location { get; set; } 

    public required CurrentApiModel Current { get; set; }

    public required ForecastApiModel Forecast { get; set; }
}
