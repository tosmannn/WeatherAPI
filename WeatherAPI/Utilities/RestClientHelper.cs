#nullable disable
using RestSharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Utilities
{
    public class RestClientHelper
    {
        public static string Get(string url)
        {
            using var client = new RestClient(url);

            var request = new RestRequest(url, Method.Get);
            var response = client.Execute(request);

            return response.Content;

        }
    }
}
