using MediatR;
using WeatherForecastApi.Application.Models;

namespace WeatherForecastApi.Application.Queries;

public class GetWeatherQuery : IRequest<WeatherQueryResult> { }