namespace WeatherForecastApi.Application.Exceptions;

public abstract class ApplicationExceptionBase(Exception? innerException = null)
    : Exception(null, innerException)
{ }