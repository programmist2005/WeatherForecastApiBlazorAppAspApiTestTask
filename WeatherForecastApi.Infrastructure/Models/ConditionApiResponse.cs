using System.Text.Json.Serialization;

namespace WeatherForecastApi.Infrastructure.Models;

public record class ConditionApiResponse
{
    //описание погоды
    [JsonPropertyName("text")] 
    public required string Text { get; set; }

    //URL иконки погоды
    [JsonPropertyName("icon")] 
    public required string Icon { get; set; }

    //код погодного условия
    [JsonPropertyName("code")]
    public int Code { get; set; }
}
