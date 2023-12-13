using System.Drawing;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;

namespace Wifi.Playlist.WeatherExtension
{
    public class CurrentWeatherProxy : ICurrentWeatherService
    {
        private CurrentWeatherService _realService;

        public CurrentWeatherProxy()
        {
            _realService = new CurrentWeatherService();
        }

        public string Description
        {
            get
            {
                if(_realService.Description == "no description")
                {
                    return "Data is loading... please wait!";
                }

                return _realService.Description;    
            }
        }       

        public string LocationName => _realService.LocationName;

        public double Temperatur => _realService.Temperatur;

        public Image Thumbnail
        {
            get
            {
                if (_realService.Thumbnail == null)
                {
                    return Resource.weather_not_available;
                }

                return _realService.Thumbnail;
            }
        }

        public async Task<bool> SetGeoLocationAsync(string city, string countryCode)
        {
            return await _realService.SetGeoLocationAsync(city, countryCode);
        }

        public async Task<bool> UpdateCurrentWeatherAsync()
        {
            return await _realService.UpdateCurrentWeatherAsync();
        }
    }
}
