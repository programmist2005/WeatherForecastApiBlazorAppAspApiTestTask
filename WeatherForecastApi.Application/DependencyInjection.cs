using Microsoft.Extensions.DependencyInjection;
using WeatherForecastApi.Application.Mapping;
using WeatherForecastApi.Application.Queries;

namespace WeatherForecastApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // MediatR
        services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(GetWeatherQueryHandler).Assembly));

        // Mappers
        services.AddTransient<WeatherQueryResultFromApiModelMapper>();

        return services;
    }
}
