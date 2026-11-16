using System.Text.Json;
using System.Text.Json.Serialization;

namespace PogodaAplikacja
{
    public class WeatherData
    {
        [JsonPropertyName("temperature_2m")]
        public double Temperature { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public double RelativeHumidity { get; set; }
    }
}