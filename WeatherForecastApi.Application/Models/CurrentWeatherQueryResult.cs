namespace WeatherForecastApi.Application.Models;

public record class CurrentWeatherQueryResult
{
    public required string City { get; set; }
    public string Region { get; set; } = null!;
    public string Country { get; set; } = null!;
    public required double TempC { get; set; }
    public required double TempF { get; set; }
    public double FeelsLikeC { get; set; }
    public double FeelsLikeF { get; set; }
    public required string ConditionText { get; set; }
    public required string ConditionIcon { get; set; }
    public double WindchillC { get; set; }
    public double WindchillF { get; set; }
    public double WindKph { get; set; }
    public double WindMph { get; set; }
    public double GustMph { get; set; }
    public double GustKph { get; set; }
    public int WindDegree { get; set; }
    public string WindDirection { get; set; } = null!;
    public int CloudPercent { get; set; }
    public int HumidityPercent { get; set; }
    public int IsDay { get; set; }
    public double Uv { get; set; }
}
