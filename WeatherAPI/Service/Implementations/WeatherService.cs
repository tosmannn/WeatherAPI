using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using WeatherAPI.Models.WeatherModels;
using WeatherAPI.Service.Interface;
using WeatherAPI.Utilities;

namespace WeatherAPI.Service.Implementations
{
    public class WeatherService : IWeatherService
    {
        #region Objects
        private readonly ILogger<WeatherService> _logger;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public WeatherService(ILogger<WeatherService> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configuration = configuration;
        }
        #endregion

        #region Public Methods

        #region CanFlyKite
        public bool CanFlyKite(WeatherRootModel model)
        {
            var isRaining = IsRaining(model);

            const int WindSpeedBelowMinimumToFlyKite = 15;

            return !isRaining && model.Current.WindSpeed > WindSpeedBelowMinimumToFlyKite;
        }
        #endregion

        #region CanGoOutside
        public bool CanGoOutside(WeatherRootModel model)
        {
            var isRaining = IsRaining(model);

            return isRaining;
        }
        #endregion

        #region GetWeather
        public WeatherRootModel GetWeather(string query)
        {
            var weatherRootModel = new WeatherRootModel();
            try
            {
                var requestUri = $"{_configuration.GetValue<string>("Url")}?access_key={_configuration.GetValue<string>("AccessKey")}&query={query}";

                var responseBody = RestClientHelper.Get(requestUri);

                weatherRootModel = JsonConvert.DeserializeObject<WeatherRootModel>(responseBody);

                _logger.LogInformation(responseBody);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
                weatherRootModel.Success = false;
            }

            return weatherRootModel;

        }
        #endregion

        #region IsSunscreenNeeded
        public bool IsSunscreenNeeded(WeatherRootModel model)
        {
            const int UVIndexLimitToGoOutside = 3;

            return model.Current.UVIndex > UVIndexLimitToGoOutside;
        }
        #endregion

        #endregion

        #region Private Methods
        #region IsRaining
        private bool IsRaining(WeatherRootModel model)
        {
            return model.Current.WeatherDescriptions
                .Where(wd => wd.ToLower().Contains("rain"))
                .Any();
        }
        #endregion
        #endregion
    }
}
