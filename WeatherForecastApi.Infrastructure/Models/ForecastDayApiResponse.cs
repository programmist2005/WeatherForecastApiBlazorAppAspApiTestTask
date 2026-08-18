using System.Text.Json.Serialization;

namespace WeatherForecastApi.Infrastructure.Models;

public record class ForecastDayApiResponse
{
    // Дата в формате YYYY-MM-DD
    [JsonPropertyName("date")]
    public required string Date { get; set; }

    // Дата в Unix timestamp
    [JsonPropertyName("date_epoch")]
    public long DateEpoch { get; set; }

    // Дневная сводка погоды
    [JsonPropertyName("day")]
    public required DayApiResponse Day { get; set; }

    // Астрономические данные (восход/закат)
    [JsonPropertyName("astro")]
    public AstroApiResponse Astro { get; set; } = new();

    // Почасовой прогноз (обычно 24 элемента)
    [JsonPropertyName("hour")]
    public List<HourApiResponse> Hour { get; set; } = new();
}