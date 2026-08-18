using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using WeatherForecast.Api.Implementation.Mapping;
using WeatherForecast.Api.Implementation.Services;
using WeatherForecastApi.Application.Interfaces;
using WeatherForecastApi.Infrastructure.Mapping;
using WeatherForecastApi.Infrastructure.Options;

namespace WeatherForecastApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //// Настройка Serilog
        //Log.Logger = new LoggerConfiguration()
        //    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        //    //.Enrich.FromLogContext()
        //    //.WriteTo.Console()
        //    .CreateBootstrapLogger();

        //services.AddLogging(loggingBuilder =>
        //{
        //    loggingBuilder.AddSerilog(dispose: true);
        //});

        // Configuration
        services.Configure<ConfigurationOptions>(configuration.GetSection("WeatherApi"));

        // HttpClient
        services.AddHttpClient<IWeatherApiClient, WeatherApiClient>();

        // Mappers
        services.AddTransient<UrlFromConfigurationOptionsMapper>();
        services.AddTransient<WeatherApiFromResponseMapper>();

        return services;
    }
}
