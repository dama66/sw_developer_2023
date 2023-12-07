using Wifi.Playlist.CoreTypes;

namespace Wifi.Playlist.Weather
{
    public class CurrentWeatherProxy : IWeatherDataProvider
    {
        private GetWeatherData _realService;

        public CurrentWeatherProxy()
        {
            _realService = new GetWeatherData();
        }

        public string Name => _realService.Name;

        public string Temp => _realService.Temp;

        public string Weather => _realService.Weather;

        public string WeatherIcon => _realService.WeatherIcon;

        public void GetWeather()
        {
            return;
        }
    }
}
