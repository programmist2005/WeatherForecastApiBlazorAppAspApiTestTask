using WeatherForecastApi.Domain.Models;
using WeatherForecastApi.Infrastructure.Models;

namespace WeatherForecast.Api.Implementation.Mapping;

public class WeatherApiFromResponseMapper
{
    public WeatherApiModel Map(WeatherApiResponse it) => new()
    {
        Current = new CurrentApiModel
        {
            LastUpdatedEpoch = it.Current.LastUpdatedEpoch,
            LastUpdated = DateTime.Parse(it.Current.LastUpdated),
            TempC = it.Current.TempC,
            TempF = it.Current.TempF,
            FeelsLikeC = it.Current.FeelsLikeC,
            FeelsLikeF = it.Current.FeelsLikeF,
            WindchillC = it.Current.WindchillC,
            WindchillF = it.Current.WindchillF,
            WindKph = it.Current.WindKph,
            WindMph = it.Current.WindMph,
            GustMph = it.Current.GustMph,
            GustKph = it.Current.GustKph,
            WindDegree = it.Current.WindDegree,
            WindDirection = it.Current.WindDirection,
            CloudPercent = it.Current.CloudPercent,
            HeatIndexC = it.Current.HeatIndexC,
            HeatIndexF = it.Current.HeatIndexF,
            Condition = new ConditionApiModel
            {
                Icon = it.Current.Condition.Icon,
                Text = it.Current.Condition.Text,
                Code = it.Current.Condition.Code
            },
            PressureInch = it.Current.PressureInch,
            PressureMiliBar = it.Current.PressureMiliBar,
            PrecipInch = it.Current.PrecipInch,
            PrecipMm = it.Current.PrecipMm,
            HumidityPercent = it.Current.HumidityPercent,
            DewpointC = it.Current.DewpointC,
            DewpointF = it.Current.DewpointF,
            IsDay = it.Current.IsDay,
            Uv = it.Current.Uv,
            AirQuality = it.Current.AirQuality != null
            ? new AirQualityApiModel
                {
                    Co = it.Current.AirQuality.Co,
                    No2 = it.Current.AirQuality.No2,
                    O3 = it.Current.AirQuality.O3,
                    So2 = it.Current.AirQuality.So2,
                    Pm2_5 = it.Current.AirQuality.Pm2_5,
                    Pm10 = it.Current.AirQuality.Pm10,
                    UsEpaIndex = it.Current.AirQuality.UsEpaIndex,
                    GbDefraIndex = it.Current.AirQuality.GbDefraIndex
                }
            : null
        },
        Location = new LocationApiModel
        {
            Name = it.Location.Name,
            Region = it.Location.Region,
            Country = it.Location.Country,
            Latitude = it.Location.Latitude,
            Longitude = it.Location.Longitude,
            TzId = it.Location.TzId,
            Localtime = DateTime.Parse(it.Location.Localtime)
        },
        Forecast = new ForecastApiModel
        {
            ForecastDay = it.Forecast.ForecastDay.Select(fd => new ForecastDayApiModel
            {
                Date = DateTime.Parse(fd.Date),
                DateEpoch = fd.DateEpoch,
                Day = new DayApiModel
                {
                    MaxTempC = fd.Day.MaxTempC,
                    MaxTempF = fd.Day.MaxTempF,
                    MinTempC = fd.Day.MinTempC,
                    MinTempF = fd.Day.MinTempF,
                    AvgTempC = fd.Day.AvgTempC,
                    AvgTempF = fd.Day.AvgTempF,
                    MaxWindMph = fd.Day.MaxWindMph,
                    MaxWindKph = fd.Day.MaxWindKph,
                    TotalPrecipMm = fd.Day.TotalPrecipMm,
                    TotalPrecipInch = fd.Day.TotalPrecipInch,
                    AvgVisKm = fd.Day.AvgVisKm,
                    AvgVisMiles = fd.Day.AvgVisMiles,
                    AvgHumidityPercent = fd.Day.AvgHumidityPercent,
                    Condition = new ConditionApiModel
                    {
                        Icon = fd.Day.Condition.Icon,
                        Text = fd.Day.Condition.Text,
                        Code = fd.Day.Condition.Code
                    },
                    Uv = fd.Day.Uv,
                    DailyWillItRain = fd.Day.DailyWillItRain,
                    DailyWillItSnow = fd.Day.DailyWillItSnow,
                    DailyChanceOfRainPercent = fd.Day.DailyChanceOfRainPercent,
                    DailyChanceOfSnowPercent = fd.Day.DailyChanceOfSnowPercent
                },
                Astro = new AstroApiModel
                {
                    Sunrise = fd.Astro.Sunrise,
                    Sunset = fd.Astro.Sunset,
                    Moonrise = fd.Astro.Moonrise,
                    Moonset = fd.Astro.Moonset,
                    MoonPhase = fd.Astro.MoonPhase,
                    MoonIlluminationPercent = fd.Astro.MoonIlluminationPercent,
                    IsMoonUp = fd.Astro.IsMoonUp,
                    IsSunUp = fd.Astro.IsSunUp
                },
                Hour = fd.Hour.Select(h => new HourApiModel
                {
                    TimeEpoch = h.TimeEpoch,
                    Time = DateTime.Parse(h.Time),
                    TempC = h.TempC,
                    TempF = h.TempF,
                    FeelsLikeC = h.FeelsLikeC,
                    FeelsLikeF = h.FeelsLikeF,
                    Condition = new ConditionApiModel
                    {
                        Icon = h.Condition.Icon,
                        Text = h.Condition.Text,
                        Code = h.Condition.Code
                    },
                    WindMph = h.WindMph,
                    WindKph = h.WindKph,
                    WindDegree = h.WindDegree,
                    WindDirection = h.WindDirection,
                    PressureInch = h.PressureInch,
                    PressureMiliBar = h.PressureMiliBar,
                    PrecipInch = h.PrecipInch,
                    PrecipMm = h.PrecipMm,
                    SnowCm = h.SnowCm,
                    HumidityPercent = h.HumidityPercent,
                    CloudPercent = h.CloudPercent,
                    GustMph = h.GustMph,
                    GustKph = h.GustKph,
                    VisKm = h.VisKm,
                    VisMiles = h.VisMiles,
                    Uv = h.Uv,
                    IsDay = h.IsDay,
                    WillItRain = h.WillItRain,
                    WillItSnow = h.WillItSnow,
                    ChanceOfRainPercent = h.ChanceOfRainPercent,
                    ChanceOfSnowPercent = h.ChanceOfSnowPercent
                }).ToList()
            }).ToList()
        }
    };
}
