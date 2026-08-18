namespace WeatherForecastApi.Domain.Models;

public record class CurrentApiModel
{
    //время последнего обновления данных о погоде
    public DateTime LastUpdated { get; set; }

    //время последнего обновления данных о погоде
    public int LastUpdatedEpoch { get; set; }

    //температура в градусах Цельсия
    public required double TempC { get; set; }

    //температура в градусах Фаренгейта
    public required double TempF { get; set; }

    //ощущаемая температура в градусах Цельсия
    public double FeelsLikeC { get; set; }

    //ощущаемая температура в градусах Фаренгейта
    public double FeelsLikeF { get; set; }

    //температура с учетом ветра в градусах Цельсия
    public double WindchillC { get; set; }

    //температура с учетом ветра в градусах Фаренгейта
    public double WindchillF { get; set; }


    //скорость ветра в км/ч
    public double WindKph { get; set; }

    //скорость ветра в милях/ч
    public double WindMph { get; set; }

    //скорость порывов ветра в милях/ч
    public double GustMph { get; set; }

    //скорость порывов ветра в км/ч
    public double GustKph { get; set; }

    //направление ветра в градусах
    public int WindDegree { get; set; }

    //направление ветра в виде текста (например, "N", "NE", "E" и т.д.)
    public string WindDirection { get; set; } = string.Empty;

    //облачность в процентах
    public int CloudPercent { get; set; }


    //индекс жары в градусах Цельсия
    public double HeatIndexC { get; set; }

    //индекс жары в градусах Фаренгейта
    public double HeatIndexF { get; set; }

    
    //описание погоды
    public required ConditionApiModel Condition { get; set; } 
    

    //давление в миллибарах
    public double PressureMiliBar { get; set; }

    //давление в дюймах
    public double PressureInch { get; set; }

    //количество осадков в мм
    public double PrecipMm { get; set; }

    //количество осадков в дюймах
    public double PrecipInch { get; set; }

    //влажность в процентах
    public int HumidityPercent { get; set; }

    //точка росы в градусах Цельсия
    public double DewpointC { get; set; }

    //точка росы в градусах Фаренгейта
    public double DewpointF { get; set; }

    //флаг дня (1 - день, 0 - ночь)
    public int IsDay { get; set; }

    //уровень ультрафиолетового излучения
    public double Uv { get; set; }

    // данные о качестве воздуха
    public AirQualityApiModel? AirQuality { get; set; } 
}
