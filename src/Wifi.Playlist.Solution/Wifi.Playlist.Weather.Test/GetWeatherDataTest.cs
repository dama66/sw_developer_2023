using GoogleMaps.LocationServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Wifi.Playlist.Weather.Test
{
    [TestFixture]
    public class GetWeatherDataTest
    {

        [Test]
        public void GestWeatherTest_class()
        {
            //get lat and lon
            var geoClient = new HttpClient();
            var geoApi = "a821e8feebfe413d200cbf4e427ffb2a";
            var weatherApi = "a3408b9d4397bde432220040aa73721f";
            var zip = "6835";
            var country = "AT";

            var geoUrl = $"http://api.openweathermap.org/geo/1.0/zip?zip={zip},{country}&appid={geoApi}";

            var geoDataResponse = geoClient.GetStringAsync(geoUrl).Result;

            var formattedGeoDataResponse = JObject.Parse(geoDataResponse);
            var lat = formattedGeoDataResponse["lat"];
            var lon = formattedGeoDataResponse["lon"];

            // get weather data
            var weatherClient = new HttpClient();

            var weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={weatherApi}&units={"metric"}";

            var weatherResponse = weatherClient.GetStringAsync(weatherUrl).Result;
            var formattedWeatherResponse = JObject.Parse(weatherResponse);

            var temp = formattedWeatherResponse["main"]["temp"];
            var weather = formattedWeatherResponse["weather"][0]["description"];
            var weatherIcon = formattedWeatherResponse["weather"][0]["icon"];
            var name = formattedWeatherResponse["name"];

        }



    }
}
