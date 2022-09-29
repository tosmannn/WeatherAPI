using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherAPI.Models.WeatherModels
{
    public class WeatherRootModel
    {
        [JsonProperty(PropertyName = "request")]
        public RequestModel? Request { get; set; }

        [JsonProperty(PropertyName = "location")]
        public LocationModel? Location { get; set; }

        [JsonProperty(PropertyName = "current")]
        public CurrentModel? Current { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; } = true;

        [JsonProperty(PropertyName = "error")]
        public ErrorModel? Error { get; set; }
    }
}
