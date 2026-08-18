using System.Text.Json.Serialization;

namespace WeatherForecastApi.Infrastructure.Models;

public record class AstroApiResponse
{
    // Восход солнца (локальное время HH:mm)
    [JsonPropertyName("sunrise")]
    public string Sunrise { get; set; } = string.Empty;

    // Закат солнца (локальное время HH:mm)
    [JsonPropertyName("sunset")]
    public string Sunset { get; set; } = string.Empty;

    // Восход луны (локальное время HH:mm)
    [JsonPropertyName("moonrise")]
    public string Moonrise { get; set; } = string.Empty;

    // Закат луны (локальное время HH:mm)
    [JsonPropertyName("moonset")]
    public string Moonset { get; set; } = string.Empty;

    // Фаза луны
    [JsonPropertyName("moon_phase")]
    public string MoonPhase { get; set; } = string.Empty;

    // Освещённость луны в процентах
    [JsonPropertyName("moon_illumination")]
    public int MoonIlluminationPercent { get; set; }

    // 1, если луна видна на небе в данное время, иначе 0
    [JsonPropertyName("is_moon_up")]
    public int IsMoonUp { get; set; }

    // 1, если солнце видно на небе в данное время, иначе 0
    [JsonPropertyName("is_sun_up")]
    public int IsSunUp { get; set; }
}
