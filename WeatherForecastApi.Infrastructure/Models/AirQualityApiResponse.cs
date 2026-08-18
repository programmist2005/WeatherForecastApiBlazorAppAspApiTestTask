using System.Text.Json.Serialization;

namespace WeatherForecastApi.Infrastructure.Models;

public record class AirQualityApiResponse
{
    // Концентрация угарного газа (CO) в мкг/м³
    [JsonPropertyName("co")]
    public double Co { get; set; }

    // Диоксид азота (NO2) в мкг/м³
    [JsonPropertyName("no2")]
    public double No2 { get; set; }

    // Озон (O3) в мкг/м³
    [JsonPropertyName("o3")]
    public double O3 { get; set; }

    // Диоксид серы (SO2) в мкг/м³
    [JsonPropertyName("so2")]
    public double So2 { get; set; }

    // Твёрдые частицы PM2.5 в мкг/м³
    [JsonPropertyName("pm2_5")]
    public double Pm2_5 { get; set; }

    // Твёрдые частицы PM10 в мкг/м³
    [JsonPropertyName("pm10")]
    public double Pm10 { get; set; }

    // Индекс качества воздуха по версии EPA США (1 — хорошо, 5 — опасно)
    [JsonPropertyName("us-epa-index")]
    public int UsEpaIndex { get; set; }

    // Индекс качества воздуха по версии Defra Великобритании (1–10)
    [JsonPropertyName("gb-defra-index")]
    public int GbDefraIndex { get; set; }
}
