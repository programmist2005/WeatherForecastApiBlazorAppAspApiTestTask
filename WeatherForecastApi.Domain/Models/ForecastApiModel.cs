namespace WeatherForecastApi.Domain.Models;

public record class ForecastApiModel
{
    public List<ForecastDayApiModel> ForecastDay { get; set; } = [];
}
