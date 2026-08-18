using Microsoft.Extensions.Options;
using Serilog;
using System.Text.Json;
using WeatherForecast.Api.Implementation.Mapping;
using WeatherForecastApi.Application.Exceptions;
using WeatherForecastApi.Application.Interfaces;
using WeatherForecastApi.Domain.Models;
using WeatherForecastApi.Infrastructure.Mapping;
using WeatherForecastApi.Infrastructure.Models;
using WeatherForecastApi.Infrastructure.Options;

namespace WeatherForecast.Api.Implementation.Services;

public class WeatherApiClient(
    HttpClient httpClient,
    IOptionsSnapshot<ConfigurationOptions> options,
    UrlFromConfigurationOptionsMapper configurationOptionsToUrlMapper,
    WeatherApiFromResponseMapper weatherApiFromResponseMapper
) : IWeatherApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ConfigurationOptions _options = options.Value;
    private readonly UrlFromConfigurationOptionsMapper _configurationOptionsToUrlMapper = configurationOptionsToUrlMapper;

    public async Task<WeatherApiModel> GetAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync(_configurationOptionsToUrlMapper.Map(_options));
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var weatherApiResponse = JsonSerializer.Deserialize<WeatherApiResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? throw new Exception("Не удалось десериализовать ответ API");

            var weatherApiModel = weatherApiFromResponseMapper.Map(weatherApiResponse);
            return weatherApiModel;
        }
        catch (InvalidOperationException ex)
        {
            Log.Error(ex, ex.Message);
            throw new ApplicationConfigurationException();
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Log.Error(ex, ex.Message);
            throw new ApplicationConfigurationException();
        }
        catch (HttpRequestException ex)
        {
            Log.Error(ex, "Ошибка при выполнении HTTP-запроса: {Message}", ex.Message);
            throw new ApplicationWeatherAPIException();
        }
        catch (JsonException ex)
        {
            Log.Error(ex, "Ошибка при десериализации ответа API: {Message}", ex.Message);
            throw new ApplicationWeatherAPIException();
        }
        catch (TaskCanceledException ex)
        {
            Log.Error(ex, "HTTP-запрос был отменен: {Message}", ex.Message);
            throw new ApplicationWeatherAPIException();
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
            throw new ApplicationWeatherAPIException();
        }
    }
}
