namespace WeatherForecastApi.Domain.Models;

public record class ConditionApiModel
{
    //описание погоды
    public required string Text { get; set; }

    //URL иконки погоды
    public required string Icon { get; set; }

    //код погодного условия
    public int Code { get; set; }
}
