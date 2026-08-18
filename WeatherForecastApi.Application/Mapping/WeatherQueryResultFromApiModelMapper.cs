using WeatherForecastApi.Application.Models;
using WeatherForecastApi.Domain.Models;

namespace WeatherForecastApi.Application.Mapping;

public class WeatherQueryResultFromApiModelMapper
{
    public WeatherQueryResult Map(WeatherApiModel it)
    {
        var cuerrenDate = DateTime.Now;
        var currentDay = cuerrenDate.Day;
        var currenHour = cuerrenDate.Hour;

        return new WeatherQueryResult
        {
            Current = new CurrentWeatherQueryResult
            {
                City = it.Location.Name,
                Region = it.Location.Region,
                Country = it.Location.Country,
                TempC = it.Current.TempC,
                TempF = it.Current.TempF,
                FeelsLikeC = it.Current.FeelsLikeC,
                FeelsLikeF = it.Current.FeelsLikeF,
                ConditionText = it.Current.Condition.Text,
                ConditionIcon = it.Current.Condition.Icon,
                WindchillC = it.Current.WindchillC,
                WindchillF = it.Current.WindchillF,
                WindKph = it.Current.WindKph,
                WindMph = it.Current.WindMph,
                GustMph = it.Current.GustMph,
                GustKph = it.Current.GustKph,
                WindDegree = it.Current.WindDegree,
                WindDirection = TranslateWindDirection(it.Current.WindDirection),
                CloudPercent = it.Current.CloudPercent,
                HumidityPercent = it.Current.HumidityPercent,
                IsDay = it.Current.IsDay,
                Uv = it.Current.Uv
            },
            Hourly = it.Forecast.ForecastDay
        .OrderBy(day => day.Date).Take(2)
        .SelectMany(x => x.Hour)
        .Where(hour => hour.Time.Day == currentDay && hour.Time.Hour >= currenHour
            || hour.Time.Day > currentDay)
        .Select(hour => new HourlyWeatherQueryResult
        {
            Time = hour.Time,
            TempC = hour.TempC,
            TempF = hour.TempF,
            FeelsLikeC = hour.FeelsLikeC,
            FeelsLikeF = hour.FeelsLikeF,
            ConditionText = hour.Condition.Text,
            ConditionIcon = hour.Condition.Icon,
            WindDegree = hour.WindDegree,
            WindDir = TranslateWindDirection(hour.WindDirection),
            PressureMiliBar = hour.PressureMiliBar,
            PressureInch = hour.PressureInch,
            CloudPercent = hour.CloudPercent,
            Uv = hour.Uv,
            ChanceOfRainPercent = hour.ChanceOfRainPercent,
            ChanceOfSnowPercent = hour.ChanceOfSnowPercent
        }).ToList(),
            Daily = it.Forecast.ForecastDay.Select(day => new DailyWeatherQueryResult
            {
                Date = day.Date,
                MaxTempC = day.Day.MaxTempC,
                MaxTempF = day.Day.MaxTempF,
                MinTempC = day.Day.MinTempC,
                MinTempF = day.Day.MinTempF,
                ConditionText = day.Day.Condition.Text,
                ConditionIcon = day.Day.Condition.Icon,
                MaxWindKph = day.Day.MaxWindKph,
                MaxWindMph = day.Day.MaxWindMph,
                Uv = day.Day.Uv,
                DailyChanceOfRainPercent = day.Day.DailyChanceOfRainPercent,
                DailyChanceOfSnowPercent = day.Day.DailyChanceOfSnowPercent
            }).ToList()
        };
    }

    private static string TranslateWindDirection(string windDirection)
    {
        var directionMap = new Dictionary<string, string>
        {
            {"N", "северный"},
            {"E", "восточный"},
            {"S", "южный"},
            {"W", "западный"},
            {"NE", "северо‑восточный"},
            {"SE", "юго‑восточный"},
            {"SW", "юго‑западный"},
            {"NW", "северо‑западный"},
            {"NNE", "северо‑северо‑восточный"},
            {"ENE", "востоко‑северо‑восточный"},
            {"ESE", "востоко‑юго‑восточный"},
            {"SSE", "юго‑юго‑восточный"},
            {"SSW", "юго‑юго‑западный"},
            {"WSW", "западо‑юго‑западный"},
            {"WNW", "западо‑северо‑западный"},
            {"NNW", "северо‑северо‑западный"}
        };

        return directionMap.TryGetValue(windDirection, out var russian)
            ? russian
            : "неизвестное направление";
    }
}
