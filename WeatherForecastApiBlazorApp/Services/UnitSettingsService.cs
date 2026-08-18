namespace WeatherForecastApiBlazorApp.Services;

public class UnitSettingsService
{
    public bool UseCelsius { get; private set; } = true;
    public bool UseKph { get; private set; } = true;

    public event Action? OnChanged;

    public void SetCelsius(bool value)
    {
        UseCelsius = value;
        OnChanged?.Invoke();
    }

    public void SetKph(bool value)
    {
        UseKph = value;
        OnChanged?.Invoke();
    }
}
