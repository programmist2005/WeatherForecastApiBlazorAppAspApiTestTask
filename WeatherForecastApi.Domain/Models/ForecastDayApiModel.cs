namespace WeatherForecastApi.Domain.Models;

public record class ForecastDayApiModel
{
    // Дата в формате YYYY-MM-DD
    public required DateTime Date { get; set; }

    // Дата в Unix timestamp
    public long DateEpoch { get; set; }

    // Дневная сводка погоды
    public required DayApiModel Day { get; set; }

    // Астрономические данные (восход/закат)
    public AstroApiModel Astro { get; set; } = new();

    // Почасовой прогноз (обычно 24 элемента)
    public List<HourApiModel> Hour { get; set; } = new();
}