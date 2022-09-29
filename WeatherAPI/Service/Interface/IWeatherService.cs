using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeatherAPI.Models.WeatherModels;

namespace WeatherAPI.Service.Interface
{
    public interface IWeatherService
    {
        WeatherRootModel GetWeather(string zipcode);

        bool CanGoOutside(WeatherRootModel model);
        bool IsSunscreenNeeded(WeatherRootModel model);
        bool CanFlyKite(WeatherRootModel model);
    }
}
