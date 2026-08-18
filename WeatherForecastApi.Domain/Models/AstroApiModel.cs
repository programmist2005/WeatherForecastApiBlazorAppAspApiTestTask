namespace WeatherForecastApi.Domain.Models;

public record class AstroApiModel
{
    // Восход солнца (локальное время HH:mm)
    public string Sunrise { get; set; } = string.Empty;

    // Закат солнца (локальное время HH:mm)
    public string Sunset { get; set; } = string.Empty;

    // Восход луны (локальное время HH:mm)
    public string Moonrise { get; set; } = string.Empty;

    // Закат луны (локальное время HH:mm)
    public string Moonset { get; set; } = string.Empty;

    // Фаза луны
    public string MoonPhase { get; set; } = string.Empty;

    // Освещённость луны в процентах
    public int MoonIlluminationPercent { get; set; }

    // 1, если луна видна на небе в данное время, иначе 0
    public int IsMoonUp { get; set; }

    // 1, если солнце видно на небе в данное время, иначе 0
    public int IsSunUp { get; set; }
}
