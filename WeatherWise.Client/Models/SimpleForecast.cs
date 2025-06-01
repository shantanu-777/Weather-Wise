//namespace WeatherWise.Client.Models
//{
//    public class SimpleForecast
//    {
//        public string Date { get; set; } = string.Empty;  
//        public string Temperature { get; set; } = string.Empty;
//        public string Weather { get; set; } = string.Empty;
//    }
//}
using System.Text.Json.Serialization;

namespace WeatherWise.Client.Models
{

    public class SimpleForecast
    {
        public string Date { get; set; } = string.Empty;
        public string Temperature { get; set; } = string.Empty;
        public string Weather { get; set; } = string.Empty;
        public int Humidity { get; set; }
        public float WindSpeed { get; set; }
        public int Pressure { get; set; }
        public string FeelsLike { get; set; } = string.Empty;
        public string Sunrise { get; set; } = string.Empty;
        public string Sunset { get; set; } = string.Empty;
    }

}