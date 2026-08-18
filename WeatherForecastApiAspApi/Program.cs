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

// Читаем origins из конфигурации
var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "API v1");
    });
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
