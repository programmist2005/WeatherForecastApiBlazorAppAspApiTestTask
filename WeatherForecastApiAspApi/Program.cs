using Serilog;
using WeatherForecastApi.Application;
using WeatherForecastApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    //.WriteTo.Console()
    //.MinimumLevel.Debug()
    .CreateBootstrapLogger();

builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
            _ = loggerConfiguration.ReadFrom.Configuration(builder.Configuration));

// Add services to the container.
builder.Services.AddControllers();

// Application services
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(config);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
