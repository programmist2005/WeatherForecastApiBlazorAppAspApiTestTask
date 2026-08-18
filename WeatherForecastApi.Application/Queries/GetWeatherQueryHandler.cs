using MediatR;
using Microsoft.Extensions.Logging;
using WeatherForecastApi.Application.Exceptions;
using WeatherForecastApi.Application.Interfaces;
using WeatherForecastApi.Application.Mapping;
using WeatherForecastApi.Application.Models;

namespace WeatherForecastApi.Application.Queries;

public class GetWeatherQueryHandler : IRequestHandler<GetWeatherQuery, WeatherQueryResult>
{
    private readonly IWeatherApiClient _client;
    private readonly WeatherQueryResultFromApiModelMapper _weatherFromApiResponseToQueryResultModelMapper;
    private readonly ILogger<GetWeatherQueryHandler> _logger;

    public GetWeatherQueryHandler(IWeatherApiClient client,
        WeatherQueryResultFromApiModelMapper weatherFromApiResponseToQueryResultModelMapper,
        ILogger<GetWeatherQueryHandler> logger)
    {
        _client = client;
        _weatherFromApiResponseToQueryResultModelMapper = weatherFromApiResponseToQueryResultModelMapper;
        _logger = logger;
    }

    public async Task<WeatherQueryResult> Handle(GetWeatherQuery request, CancellationToken ct)
    {
        try
        {
            var weatherApiResponse = await _client.GetAsync();
            var weatherQueryResult = _weatherFromApiResponseToQueryResultModelMapper.Map(weatherApiResponse);
            return weatherQueryResult;
        }
        catch (ApplicationConfigurationException) { throw; }
        catch (ApplicationWeatherAPIException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при обработке запроса GetWeatherQuery: {Message}", ex.Message);
            throw new ApplicationUnknownException();
        }
    }
}