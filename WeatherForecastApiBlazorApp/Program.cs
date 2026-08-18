using Serilog;
using WeatherForecastApiBlazorApp.Components;
using WeatherForecastApiBlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    //.WriteTo.Console()
    //.MinimumLevel.Debug()
    .CreateBootstrapLogger();

builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
            _ = loggerConfiguration.ReadFrom.Configuration(builder.Configuration));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Application services
builder.Services.AddSingleton<UnitSettingsService>();

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
