using System.Text.Json.Serialization;

namespace WeatherForecastApi.Infrastructure.Models;

public record class ForecastApiResponse
{
    [JsonPropertyName("forecastday")]
    public List<ForecastDayApiResponse> ForecastDay { get; set; } = [];
}
