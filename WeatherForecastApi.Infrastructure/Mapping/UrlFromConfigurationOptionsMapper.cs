using Microsoft.AspNetCore.WebUtilities;
using System.Globalization;
using WeatherForecastApi.Infrastructure.Options;

namespace WeatherForecastApi.Infrastructure.Mapping;

public class UrlFromConfigurationOptionsMapper
{
    public Uri Map(ConfigurationOptions it)
    {
        // Валидация BaseUrl
        if (!Uri.TryCreate(it.BaseUrl, UriKind.Absolute, out var baseUri))
            throw new InvalidOperationException($"Некорректный BaseUrl: {it.BaseUrl}");

        // Валидация географических координат
        if (it.Latitude < -90 || it.Latitude > 90)
            throw new ArgumentOutOfRangeException(nameof(it.Latitude),
                "Широта (Latitude) должна быть в диапазоне от -90 до 90 градусов");

        if (it.Longitude < -180 || it.Longitude > 180)
            throw new ArgumentOutOfRangeException(nameof(it.Longitude),
                "Долгота (Longitude) должна быть в диапазоне от -180 до 180 градусов");

        // Валидация количества дней прогноза
        if (it.Days < 1 || it.Days > 3)
            throw new ArgumentOutOfRangeException(nameof(it.Days),
                "Количество дней (Days) должно быть в диапазоне от 1 до 3");

        // Форматирование координат с точностью до 4 знаков после запятой
        var coordinates = $"{it.Latitude.ToString("F4", new CultureInfo("en-US"))},{it.Longitude.ToString("F4", new CultureInfo("en-US"))}";

        // Формирование параметров запроса
        var queryParams = new Dictionary<string, string?>
        {
            ["key"] = it.Key,
            ["q"] = coordinates,
            ["days"] = it.Days.ToString()
        };

        if (!string.IsNullOrEmpty(it.Language)) queryParams["lang"] = it.Language;
        if (!string.IsNullOrEmpty(it.Aqi) || it.Aqi == "yes") queryParams["aqi"] = it.Aqi;

        // Построение базового пути (гарантируем отсутствие дублирующего слеша)
        var basePath = baseUri.AbsoluteUri.TrimEnd('/') + "/forecast.json";

        // Добавление параметров запроса с корректным кодированием
        var fullUrl = QueryHelpers.AddQueryString(basePath, queryParams);

        // Финальная проверка сформированного URL
        if (!Uri.TryCreate(fullUrl, UriKind.Absolute, out var resultUri))
            throw new InvalidOperationException($"Не удалось сформировать корректный URL: {fullUrl}");

        return resultUri;
    }
}
