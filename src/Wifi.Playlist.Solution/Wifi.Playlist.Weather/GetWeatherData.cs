using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Wifi.Playlist.CoreTypes;


namespace Wifi.Playlist.Weather
{
    public class GetWeatherData : IWeatherDataProvider
    {
        private string _name;
        private string _temp;
        private string _weather;
        private string _weatherIcon;


        public string Name => _name;

        public string Temp => _temp;

        public string Weather => _weather;

        public string WeatherIcon => _weatherIcon;

        public void GetWeather()
        {
            //get lat and lon
            var _geoClient = new HttpClient();
            var _geoApi = "a821e8feebfe413d200cbf4e427ffb2a";

            var _zip = "6800";
            var _country = "AT";

            var _geoUrl = $"http://api.openweathermap.org/geo/1.0/zip?zip={_zip},{_country}&appid={_geoApi}";

            var _geoDataResponse = _geoClient.GetStringAsync(_geoUrl).Result;

            var _formattedGeoDataResponse = JObject.Parse(_geoDataResponse);
            var _lat = _formattedGeoDataResponse["lat"];
            var _lon = _formattedGeoDataResponse["lon"];


            // get weather data

            var _weatherClient = new HttpClient();
            var _weatherApi = "a3408b9d4397bde432220040aa73721f";

            var _weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={_lat}&lon={_lon}&appid={_weatherApi}&units={"metric"}";

            var _weatherResponse = _weatherClient.GetStringAsync(_weatherUrl).Result;
            var _formattedWeatherResponse = JObject.Parse(_weatherResponse);

            _temp = JsonConvert.SerializeObject(_formattedWeatherResponse["main"]["temp"]);
            _weather = JsonConvert.SerializeObject(_formattedWeatherResponse["weather"][0]["description"]);
            _weatherIcon = JsonConvert.SerializeObject(_formattedWeatherResponse["weather"][0]["icon"]);
            _name = JsonConvert.SerializeObject(_formattedWeatherResponse["name"]);

            _temp = _temp.Replace("\"", "");
            _weather = _weather.Replace("\"","");
            _weatherIcon = _weatherIcon.Replace("\"","");
            _name = _name.Replace("\"","");

        }
    }
}
