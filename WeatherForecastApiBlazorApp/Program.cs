using Microsoft.Extensions.Options;
using Serilog;
using WeatherForecastApiBlazorApp.Components;
using WeatherForecastApiBlazorApp.Options;
using WeatherForecastApiBlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    //.WriteTo.Console()
    //.MinimumLevel.Debug()
    .CreateBootstrapLogger();

builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
            _ = loggerConfiguration.ReadFrom.Configuration(builder.Configuration));

// Application services
builder.Services.AddSingleton<UnitSettingsService>();
builder.Services.AddScoped<WeatherService>();

builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection("ApiOptions"));
builder.Services.AddHttpClient("ApiClient", (sp, client) =>
{
    var settings = sp.GetRequiredService<IOptions<ApiOptions>>().Value;
    client.BaseAddress = new Uri(settings.BaseUrl);
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
