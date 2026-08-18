namespace WeatherForecastApi.Domain.Models;

public record class DayApiModel
{
    // Максимальная температура днём в градусах Цельсия
    public required decimal MaxTempC { get; set; }

    // Максимальная температура днём в градусах Фаренгейта
    public required decimal MaxTempF { get; set; }

    // Минимальная температура ночью в градусах Цельсия
    public required decimal MinTempC { get; set; }

    // Минимальная температура ночью в градусах Фаренгейта
    public required decimal MinTempF { get; set; }

    // Средняя температура за деньё в градусах Цельсия
    public decimal AvgTempC { get; set; }

    // Средняя температура за деньё в градусах Фаренгейта
    public decimal AvgTempF { get; set; }

    // Максимальная скорость ветра в милях в час
    public decimal MaxWindMph { get; set; }

    // Максимальная скорость ветра в километрах в час   
    public decimal MaxWindKph { get; set; }

    // Суммарные осадки за день в миллиметрах
    public decimal TotalPrecipMm { get; set; }

    // Суммарные осадки за день в дюймах
    public decimal TotalPrecipInch { get; set; }

    // Суммарный снег за день в сантиметрах
    public decimal TotalSnowCm { get; set; }

    // Средняя видимость за день в километрах
    public decimal AvgVisKm { get; set; }

    // Средняя видимость за день в милях
    public decimal AvgVisMiles { get; set; }

    // Средняя влажность за день в процентах
    public int AvgHumidityPercent { get; set; }

    // Погодное условие
    public required ConditionApiModel Condition { get; set; }

    // UV-индекс
    public decimal Uv { get; set; }

    // Будет ли дождь/снег (1 - да, 0 - нет)
    public int DailyWillItRain { get; set; }

    // Будет ли снег (1 - да, 0 - нет)
    public int DailyWillItSnow { get; set; }

    // Вероятность в процентах дождя в течение дня
    public int DailyChanceOfRainPercent { get; set; }

    // Вероятность в процентах снега в течение дня
    public int DailyChanceOfSnowPercent { get; set; }
}