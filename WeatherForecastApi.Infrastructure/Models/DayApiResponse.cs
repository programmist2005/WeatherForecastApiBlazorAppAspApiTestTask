using System.Text.Json.Serialization;

namespace WeatherForecastApi.Infrastructure.Models;

public record class DayApiResponse
{
    // Максимальная температура днём в градусах Цельсия
    [JsonPropertyName("maxtemp_c")]
    public required decimal MaxTempC { get; set; }

    // Максимальная температура днём в градусах Фаренгейта
    [JsonPropertyName("maxtemp_f")]
    public required decimal MaxTempF { get; set; }

    // Минимальная температура ночью в градусах Цельсия
    [JsonPropertyName("mintemp_c")]
    public required decimal MinTempC { get; set; }

    // Минимальная температура ночью в градусах Фаренгейта
    [JsonPropertyName("mintemp_f")]
    public required decimal MinTempF { get; set; }

    // Средняя температура за деньё в градусах Цельсия
    [JsonPropertyName("avgtemp_c")]
    public decimal AvgTempC { get; set; }

    // Средняя температура за деньё в градусах Фаренгейта
    [JsonPropertyName("avgtemp_f")]
    public decimal AvgTempF { get; set; }

    // Максимальная скорость ветра в милях в час
    [JsonPropertyName("maxwind_mph")]
    public decimal MaxWindMph { get; set; }

    // Максимальная скорость ветра в километрах в час   
    [JsonPropertyName("maxwind_kph")]
    public decimal MaxWindKph { get; set; }

    // Суммарные осадки за день в миллиметрах
    [JsonPropertyName("totalprecip_mm")]
    public decimal TotalPrecipMm { get; set; }

    // Суммарные осадки за день в дюймах
    [JsonPropertyName("totalprecip_in")]
    public decimal TotalPrecipInch { get; set; }

    // Суммарный снег за день в сантиметрах
    [JsonPropertyName("totalsnow_cm")]
    public decimal TotalSnowCm { get; set; }

    // Средняя видимость за день в километрах
    [JsonPropertyName("avgvis_km")]
    public decimal AvgVisKm { get; set; }

    // Средняя видимость за день в милях
    [JsonPropertyName("avgvis_miles")]
    public decimal AvgVisMiles { get; set; }

    // Средняя влажность за день в процентах
    [JsonPropertyName("avghumidity")]
    public int AvgHumidityPercent { get; set; }

    // Погодное условие
    [JsonPropertyName("condition")]
    public required ConditionApiResponse Condition { get; set; }

    // UV-индекс
    [JsonPropertyName("uv")]
    public decimal Uv { get; set; }

    // Будет ли дождь/снег (1 - да, 0 - нет)
    [JsonPropertyName("daily_will_it_rain")]
    public int DailyWillItRain { get; set; }

    // Будет ли снег (1 - да, 0 - нет)
    [JsonPropertyName("daily_will_it_snow")]
    public int DailyWillItSnow { get; set; }

    // Вероятность в процентах дождя в течение дня
    [JsonPropertyName("daily_chance_of_rain")]
    public int DailyChanceOfRainPercent { get; set; }

    // Вероятность в процентах снега в течение дня
    [JsonPropertyName("daily_chance_of_snow")]
    public int DailyChanceOfSnowPercent { get; set; }
}