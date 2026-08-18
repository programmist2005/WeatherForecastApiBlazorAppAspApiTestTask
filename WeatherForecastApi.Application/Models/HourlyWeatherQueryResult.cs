namespace WeatherForecastApi.Application.Models;

public record class HourlyWeatherQueryResult
{
    public required DateTime Time { get; set; }
    public required decimal TempC { get; set; }
    public required decimal TempF { get; set; }
    public decimal FeelsLikeC { get; set; }
    public decimal FeelsLikeF { get; set; }
    public required string ConditionText { get; set; }
    public required string ConditionIcon { get; set; }
    public int WindDegree { get; set; }
    public string WindDir { get; set; } = string.Empty;
    public decimal PressureMiliBar { get; set; }
    public decimal PressureInch { get; set; }
    public int CloudPercent { get; set; }
    public decimal Uv { get; set; }
    public int ChanceOfRainPercent { get; set; }
    public int ChanceOfSnowPercent { get; set; }
}
