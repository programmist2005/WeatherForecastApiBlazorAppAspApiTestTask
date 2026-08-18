using System.Text.Json.Serialization;

namespace WeatherForecastApi.Infrastructure.Models;

public record class WeatherApiResponse
{
    [JsonPropertyName("location")]
    public required LocationApiResponse Location { get; set; } 

    [JsonPropertyName("current")]
    public required CurrentApiResponse Current { get; set; }

    [JsonPropertyName("forecast")]
    public required ForecastApiResponse Forecast { get; set; }
}
