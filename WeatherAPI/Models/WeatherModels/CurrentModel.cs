#nullable disable

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Models.WeatherModels
{
    public class CurrentModel
    {
        [JsonProperty(PropertyName = "observation_time")]
        public string ObservationTime { get; set; }

        [JsonProperty(PropertyName = "temperature")]
        public int Temperature { get; set; }

        [JsonProperty(PropertyName = "weather_code")]
        public int WeatherCode { get; set; }

        [JsonProperty(PropertyName = "weather_icons")]
        public List<string> WeatherIcons { get; set; }

        [JsonProperty(PropertyName = "weather_descriptions")]
        public List<string> WeatherDescriptions { get; set; }

        [JsonProperty(PropertyName = "wind_speed")]
        public int WindSpeed { get; set; }

        [JsonProperty(PropertyName = "wind_degree")]
        public int WindDegree { get; set; }

        [JsonProperty(PropertyName = "wind_dir")]
        public string WindDir { get; set; }

        [JsonProperty(PropertyName = "pressure")]
        public int Pressure { get; set; }

        [JsonProperty(PropertyName = "precip")]
        public int Precip { get; set; }

        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get; set; }

        [JsonProperty(PropertyName = "cloudcover")]
        public int Cloudcover { get; set; }

        [JsonProperty(PropertyName = "feelslike")]
        public int Feelslike { get; set; }

        [JsonProperty(PropertyName = "uv_index")]
        public int UVIndex { get; set; }

        [JsonProperty(PropertyName = "visibility")]
        public int Visibility { get; set; }

        [JsonProperty(PropertyName = "is_day")]
        public string IsDay { get; set; }
    }
}
