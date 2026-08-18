namespace WeatherForecastApi.Domain.Models;

public record class AirQualityApiModel
{
    // Концентрация угарного газа (CO) в мкг/м³
    public double Co { get; set; }

    // Диоксид азота (NO2) в мкг/м³
    public double No2 { get; set; }

    // Озон (O3) в мкг/м³
    public double O3 { get; set; }

    // Диоксид серы (SO2) в мкг/м³
    public double So2 { get; set; }

    // Твёрдые частицы PM2.5 в мкг/м³
    public double Pm2_5 { get; set; }

    // Твёрдые частицы PM10 в мкг/м³
    public double Pm10 { get; set; }

    // Индекс качества воздуха по версии EPA США (1 — хорошо, 5 — опасно)
    public int UsEpaIndex { get; set; }

    // Индекс качества воздуха по версии Defra Великобритании (1–10)
    public int GbDefraIndex { get; set; }
}
