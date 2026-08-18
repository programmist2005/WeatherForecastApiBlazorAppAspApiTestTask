using Serilog;
using WeatherForecastApiBlazorApp.Models;

namespace WeatherForecastApiBlazorApp.Services;

public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<WeatherQueryResult?> GetWeatherAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/weather");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<WeatherQueryResult>();
            }

            var errorMessage = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:          // 400
                    Log.Warning("400 - Ошибка конфигурации: {Message}", errorMessage);
                    throw new ApplicationException("400 - Ошибка конфигурации запроса");

                case System.Net.HttpStatusCode.BadGateway:          // 502
                    Log.Warning("502 - Ошибка внешнего API: {Message}", errorMessage);
                    throw new ApplicationException("502 - Ошибка получения данных о погоде");

                case System.Net.HttpStatusCode.InternalServerError: // 500
                    Log.Error("500 - Внутренняя ошибка сервера: {Message}", errorMessage);
                    throw new ApplicationException("500 - Произошла неизвестная ошибка");

                default:
                    Log.Error("Неожиданный статус {StatusCode}: {Message}", response.StatusCode, errorMessage);
                    throw new ApplicationException($"Ошибка сервера: {(int)response.StatusCode}");
            }
        }
        catch (HttpRequestException ex)
        {
            Log.Error(ex, "Ошибка сети при обращении к API");
            throw new ApplicationException("Не удалось связаться с сервером");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Непредвиденная ошибка при получении погоды");
            throw new ApplicationException("Непредвиденная ошибка при получении погоды");
        }
    }
}
