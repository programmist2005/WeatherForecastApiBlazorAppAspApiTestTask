using System.Text.Json.Serialization;

namespace WeatherForecastApi.Infrastructure.Models;

public record class CurrentApiResponse
{
    //время последнего обновления данных о погоде
    [JsonPropertyName("last_updated")]
    public string LastUpdated { get; set; } = string.Empty;

    //время последнего обновления данных о погоде
    [JsonPropertyName("last_updated_epoch")]
    public int LastUpdatedEpoch { get; set; }

    //температура в градусах Цельсия
    [JsonPropertyName("temp_c")]
    public required double TempC { get; set; }

    //температура в градусах Фаренгейта
    [JsonPropertyName("temp_f")]
    public required double TempF { get; set; }

    //ощущаемая температура в градусах Цельсия
    [JsonPropertyName("feelslike_c")] 
    public double FeelsLikeC { get; set; }

    //ощущаемая температура в градусах Фаренгейта
    [JsonPropertyName("feelslike_f")]
    public double FeelsLikeF { get; set; }

    //температура с учетом ветра в градусах Цельсия
    [JsonPropertyName("windchill_c")]
    public double WindchillC { get; set; }

    //температура с учетом ветра в градусах Фаренгейта
    [JsonPropertyName("windchill_f")]
    public double WindchillF { get; set; }


    //скорость ветра в км/ч
    [JsonPropertyName("wind_kph")]
    public double WindKph { get; set; }

    //скорость ветра в милях/ч
    [JsonPropertyName("wind_mph")]
    public double WindMph { get; set; }

    //скорость порывов ветра в милях/ч
    [JsonPropertyName("gust_mph")]
    public double GustMph { get; set; }

    //скорость порывов ветра в км/ч
    [JsonPropertyName("gust_kph")]
    public double GustKph { get; set; }

    //направление ветра в градусах
    [JsonPropertyName("wind_degree")]
    public int WindDegree { get; set; }

    //направление ветра в виде текста (например, "N", "NE", "E" и т.д.)
    [JsonPropertyName("wind_dir")]
    public string WindDirection { get; set; } = string.Empty;

    //облачность в процентах
    [JsonPropertyName("cloud")]
    public int CloudPercent { get; set; }


    //индекс жары в градусах Цельсия
    [JsonPropertyName("heatindex_c")]
    public double HeatIndexC { get; set; }

    //индекс жары в градусах Фаренгейта
    [JsonPropertyName("heatindex_f")]
    public double HeatIndexF { get; set; }

    
    //описание погоды
    [JsonPropertyName("condition")] 
    public required ConditionApiResponse Condition { get; set; } = null!;
    

    //давление в миллибарах
    [JsonPropertyName("pressure_mb")]
    public double PressureMiliBar { get; set; }

    //давление в дюймах
    [JsonPropertyName("pressure_in")]
    public double PressureInch { get; set; }

    //количество осадков в мм
    [JsonPropertyName("precip_mm")]
    public double PrecipMm { get; set; }

    //количество осадков в дюймах
    [JsonPropertyName("precip_in")]
    public double PrecipInch { get; set; }

    //влажность в процентах
    [JsonPropertyName("humidity")] 
    public int HumidityPercent { get; set; }

    //точка росы в градусах Цельсия
    [JsonPropertyName("dewpoint_c")]
    public double DewpointC { get; set; }

    //точка росы в градусах Фаренгейта
    [JsonPropertyName("dewpoint_f")]
    public double DewpointF { get; set; }

    //флаг дня (1 - день, 0 - ночь)
    [JsonPropertyName("is_day")]
    public int IsDay { get; set; }

    //уровень ультрафиолетового излучения
    [JsonPropertyName("uv")] 
    public double Uv { get; set; }

    // данные о качестве воздуха
    [JsonPropertyName("air_quality")]
    public AirQualityApiResponse AirQuality { get; set; } = null!;
}
