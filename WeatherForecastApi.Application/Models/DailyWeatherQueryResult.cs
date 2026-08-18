namespace WeatherForecastApi.Application.Models;

public record class DailyWeatherQueryResult
{
    public required DateTime Date { get; set; }
    public required decimal MaxTempC { get; set; }
    public required decimal MinTempC { get; set; }
    public required decimal MaxTempF { get; set; }
    public required decimal MinTempF { get; set; }
    public required string ConditionText { get; set; }
    public required string ConditionIcon { get; set; }
    public decimal MaxWindMph { get; set; }
    public decimal MaxWindKph { get; set; }
    public decimal Uv { get; set; }
    public int DailyChanceOfRainPercent { get; set; }
    public int DailyChanceOfSnowPercent { get; set; }
}
