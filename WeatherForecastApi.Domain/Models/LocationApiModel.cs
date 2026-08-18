namespace WeatherForecastApi.Domain.Models;

public record class LocationApiModel
{
    //широта
    public decimal Latitude { get; set; }

    //долгота
    public decimal Longitude { get; set; }

    //название города
    public required string Name { get; set; } = string.Empty;

    //название региона
    public string Region { get; set; } = string.Empty;

    //название страны
    public string Country { get; set; } = string.Empty;

    //часовой пояс
    public string TzId { get; set; } = string.Empty;

    //местное время
    public DateTime Localtime { get; set; }
}
