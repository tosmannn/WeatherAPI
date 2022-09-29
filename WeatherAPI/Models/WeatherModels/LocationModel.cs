#nullable disable
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Models.WeatherModels
{
    public class LocationModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "tregionype")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public string Lat { get; set; }

        [JsonProperty(PropertyName = "lon")]
        public string Lon { get; set; }

        [JsonProperty(PropertyName = "timezone_id")]
        public string TimezondId { get; set; }


        [JsonProperty(PropertyName = "localtime")]
        public string LocalTime { get; set; }

        [JsonProperty(PropertyName = "localtime_epoch")]
        public int LocalTimeEpoch { get; set; }

        [JsonProperty(PropertyName = "utc_offset")]
        public string UtcOffset { get; set; }
    }
}
