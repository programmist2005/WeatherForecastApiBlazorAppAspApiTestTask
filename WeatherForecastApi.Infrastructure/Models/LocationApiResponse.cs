using System.Text.Json.Serialization;

namespace WeatherForecastApi.Infrastructure.Models;

public record class LocationApiResponse
{
    //широта
    [JsonPropertyName("lat")]
    public decimal Latitude { get; set; }

    //долгота
    [JsonPropertyName("lon")]
    public decimal Longitude { get; set; }

    //название города
    [JsonPropertyName("name")]
    public required string Name { get; set; } = string.Empty;

    //название региона
    [JsonPropertyName("region")]
    public string Region { get; set; } = string.Empty;

    //название страны
    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    //часовой пояс
    [JsonPropertyName("tz_id")]
    public string TzId { get; set; } = string.Empty;

    //местное время
    [JsonPropertyName("localtime")]
    public string Localtime { get; set; } = string.Empty;
}
