using System.Text.Json.Serialization;

namespace WeatherForecastApi.Infrastructure.Models;

public record class HourApiResponse
{
    // Время часа
    [JsonPropertyName("time_epoch")]
    public long TimeEpoch { get; set; }

    // Время в формате YYYY-MM-DD HH:mm
    [JsonPropertyName("time")]
    public required string Time { get; set; }

    // Температура в градусах Цельсия
    [JsonPropertyName("temp_c")]
    public required decimal TempC { get; set; }

    // Температура в градусах Фаренгейта
    [JsonPropertyName("temp_f")]
    public decimal TempF { get; set; }

    // Ощущается как температура в градусах Цельсия
    [JsonPropertyName("feelslike_c")]
    public decimal FeelsLikeC { get; set; }

    // Ощущается как температура в градусах Фаренгейта
    [JsonPropertyName("feelslike_f")]
    public decimal FeelsLikeF { get; set; }

    // Погодное условие
    [JsonPropertyName("condition")]
    public required ConditionApiResponse Condition { get; set; }

    // Ветер в милях в час
    [JsonPropertyName("wind_mph")]
    public decimal WindMph { get; set; }

    // Ветер в километрах в час
    [JsonPropertyName("wind_kph")]
    public decimal WindKph { get; set; }

    // Направление ветра в градусах
    [JsonPropertyName("wind_degree")]
    public int WindDegree { get; set; }

    // Направление ветра в виде текста (например, "N", "NE", "E" и т.д.)
    [JsonPropertyName("wind_dir")]
    public string WindDirection { get; set; } = string.Empty;

    // Давление в миллибарах
    [JsonPropertyName("pressure_mb")]
    public decimal PressureMiliBar { get; set; }

    // Давление в дюймах
    [JsonPropertyName("pressure_in")]
    public decimal PressureInch { get; set; }

    // Осадки в миллиметрах
    [JsonPropertyName("precip_mm")]
    public decimal PrecipMm { get; set; }

    // Осадки в дюймах
    [JsonPropertyName("precip_in")]
    public decimal PrecipInch { get; set; }

    // Снег в сантиметрах
    [JsonPropertyName("snow_cm")]
    public decimal SnowCm { get; set; }

    // Влажность и облачность в процентах
    [JsonPropertyName("humidity")]
    public int HumidityPercent { get; set; }

    // Облачность в процентах
    [JsonPropertyName("cloud")]
    public int CloudPercent { get; set; }

    // Порывы ветра в милях в час
    [JsonPropertyName("gust_mph")]
    public decimal GustMph { get; set; }
    
    // Порывы ветра в километрах в час
    [JsonPropertyName("gust_kph")]
    public decimal GustKph { get; set; }

    // Видимость в километрах
    [JsonPropertyName("vis_km")]
    public decimal VisKm { get; set; }

    // Видимость в милях
    [JsonPropertyName("vis_miles")]
    public decimal VisMiles { get; set; }

    // UV
    [JsonPropertyName("uv")]
    public decimal Uv { get; set; }

    // Является ли это дневным временем (1 - да, 0 - нет)
    [JsonPropertyName("is_day")]
    public int IsDay { get; set; }

    // Вероятность осадков (1 - да, 0 - нет)
    [JsonPropertyName("will_it_rain")]
    public int WillItRain { get; set; }

    // Вероятность снега (1 - да, 0 - нет)
    [JsonPropertyName("will_it_snow")]
    public int WillItSnow { get; set; }

    // Вероятность дождя в процентах
    [JsonPropertyName("chance_of_rain")]
    public int ChanceOfRainPercent { get; set; }

    // Вероятность снега в процентах    
    [JsonPropertyName("chance_of_snow")]
    public int ChanceOfSnowPercent { get; set; }
}