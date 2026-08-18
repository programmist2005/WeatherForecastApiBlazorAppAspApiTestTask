namespace WeatherForecastApi.Infrastructure.Options;

public record class ConfigurationOptions
{
    public required string Key { get; set; }
    public required string BaseUrl { get; set; }
    public required decimal Latitude { get; set; }
    public required decimal Longitude { get; set; }
    public required byte Days { get; set; }
    public string? Language { get; set; }
    public string? Aqi { get; set; }
}
