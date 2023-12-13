using RestSharp;
using Wifi.Playlist.WeatherExtension.Entities;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System;
using System.IO;
using System.Drawing;
using Wifi.Playlist.CoreTypes;

namespace Wifi.Playlist.WeatherExtension
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        //ToDo: https://techcommunity.microsoft.com/t5/apps-on-azure-blog/how-to-store-app-secrets-for-your-asp-net-core-project/ba-p/1527531
        private static string API_KEY = "7ff2da64686f8e94c04090eb7e36abcd";

        private double _lat;
        private double _lon;
        private string _locationName;
        private double _temperatur;
        private string _weatherDescription;
        private Image _image;

        public CurrentWeatherService()
        {
            _lat = 0.0;
            _lon = 0.0;
            _locationName = "no name";
            _weatherDescription = "no description";
            _temperatur = double.NaN;
            _image = null;
        }

        public string LocationName => _locationName;

        public Image Thumbnail => _image;

        public string Description => _weatherDescription;

        public double Temperatur => _temperatur;

        public async Task<bool> UpdateCurrentWeatherAsync(string city, string countryCode)
        {
            if (await SetGeoLocationAsync(city, countryCode))
            {
                return await UpdateCurrentWeatherAsync();
            }

            return false;
        }

        public async Task<bool> UpdateCurrentWeatherAsync()
        {
            var options = new RestClientOptions("https://api.openweathermap.org/data/2.5");
            var client = new RestClient(options);

            var request = new RestRequest($"weather?lat={_lat:F6}&lon={_lon:F6}&units=metric&lang=de&appid={API_KEY}", Method.Get);

            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content))
            {
                var weatherData = JsonConvert.DeserializeObject<CurrentWeather>(response.Content);

                if (weatherData != null && weatherData.weather != null)
                {
                    _temperatur = (double)weatherData.main.temp;

                    _weatherDescription = weatherData.weather[0].description;

                    var iconUri = $"http://openweathermap.org/img/wn/{weatherData.weather[0].icon}@4x.png";
                    _image = DownloadImageFromUrl(iconUri);

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> SetGeoLocationAsync(string city, string countryCode)
        {
            var options = new RestClientOptions("http://api.openweathermap.org/geo/1.0");
            var client = new RestClient(options);

            var request = new RestRequest($"direct?q={city},{countryCode}&appid={API_KEY}", Method.Get);

            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content))
            {
                var locations = JsonConvert.DeserializeObject<LocationDetail[]>(response.Content);

                if (locations.Length > 0)
                {
                    _lat = locations[0].lat;
                    _lon = locations[0].lon;
                    _locationName = locations[0].name;

                    return true;
                }
            }

            return false;
        }

        private Image DownloadImageFromUrl(string imageUrl)
        {
            Image image = null;

            try
            {
                var uri = new Uri(imageUrl);

                ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, ssl) => true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13 | SecurityProtocolType.Tls12;

                var client = new WebClient();
                var data = client.DownloadData(uri);
                image = Image.FromStream(new MemoryStream(data));
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }
    }
}