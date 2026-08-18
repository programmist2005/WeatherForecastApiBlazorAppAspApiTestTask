using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WeatherForecastApi.Application.Exceptions;
using WeatherForecastApi.Application.Models;
using WeatherForecastApi.Application.Queries;

namespace WeatherForecastApiAspApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : Controller
{
    private readonly IMediator _mediator;

    public WeatherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(WeatherQueryResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetWeather(CancellationToken cancellationToken)
    {
        try
        {
            var weather = await _mediator.Send(new GetWeatherQuery(), cancellationToken);
            return Ok(weather);
        }
        catch (ApplicationConfigurationException ex)
        {
            Log.Error(ex, "Ошибка конфигурации при получении погоды");
            return BadRequest("Ошибка конфигурации запроса");
        }
        catch (ApplicationWeatherAPIException ex)
        {
            Log.Error(ex, "Ошибка внешнего API погоды");
            return StatusCode(StatusCodes.Status502BadGateway, "Ошибка получения данных о погоде");
        }
        catch (ApplicationUnknownException ex)
        {
            Log.Error(ex, "Неизвестная ошибка при получении погоды");
            return StatusCode(StatusCodes.Status500InternalServerError, "Произошла неизвестная ошибка");
        }
    }
}
