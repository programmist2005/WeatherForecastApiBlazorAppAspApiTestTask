using WeatherForecastApi.Domain.Models;

namespace WeatherForecastApi.Application.Interfaces;

public interface IWeatherApiClient
{
    Task<WeatherApiModel> GetAsync();
}