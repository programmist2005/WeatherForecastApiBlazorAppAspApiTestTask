namespace WeatherForecastApi.Domain.Models;

public record class HourApiModel
{
    // Время часа
    public long TimeEpoch { get; set; }

    // Время в формате YYYY-MM-DD HH:mm
    public required DateTime Time { get; set; }

    // Температура в градусах Цельсия
    public required decimal TempC { get; set; }

    // Температура в градусах Фаренгейта
    public decimal TempF { get; set; }

    // Ощущается как температура в градусах Цельсия
    public decimal FeelsLikeC { get; set; }

    // Ощущается как температура в градусах Фаренгейта
    public decimal FeelsLikeF { get; set; }

    // Погодное условие
    public required ConditionApiModel Condition { get; set; }

    // Ветер в милях в час
    public decimal WindMph { get; set; }

    // Ветер в километрах в час
    public decimal WindKph { get; set; }

    // Направление ветра в градусах
    public int WindDegree { get; set; }

    // Направление ветра в виде текста (например, "N", "NE", "E" и т.д.)
    public string WindDirection { get; set; } = string.Empty;

    // Давление в миллибарах
    public decimal PressureMiliBar { get; set; }

    // Давление в дюймах
    public decimal PressureInch { get; set; }

    // Осадки в миллиметрах
    public decimal PrecipMm { get; set; }

    // Осадки в дюймах
    public decimal PrecipInch { get; set; }

    // Снег в сантиметрах
    public decimal SnowCm { get; set; }

    // Влажность и облачность в процентах
    public int HumidityPercent { get; set; }

    // Облачность в процентах
    public int CloudPercent { get; set; }

    // Порывы ветра в милях в час
    public decimal GustMph { get; set; }
    
    // Порывы ветра в километрах в час
    public decimal GustKph { get; set; }

    // Видимость в километрах
    public decimal VisKm { get; set; }

    // Видимость в милях
    public decimal VisMiles { get; set; }

    // UV
    public decimal Uv { get; set; }

    // Является ли это дневным временем (1 - да, 0 - нет)
    public int IsDay { get; set; }

    // Вероятность осадков (1 - да, 0 - нет)
    public int WillItRain { get; set; }

    // Вероятность снега (1 - да, 0 - нет)
    public int WillItSnow { get; set; }

    // Вероятность дождя в процентах
    public int ChanceOfRainPercent { get; set; }

    // Вероятность снега в процентах    
    public int ChanceOfSnowPercent { get; set; }
}