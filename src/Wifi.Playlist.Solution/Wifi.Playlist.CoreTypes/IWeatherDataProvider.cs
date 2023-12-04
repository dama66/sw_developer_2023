using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Playlist.CoreTypes
{
    public interface IWeatherDataProvider
    {
        string Name { get; }
        string Temp { get; }
        string Weather { get; }
        string WeatherIcon { get; }

       void GetWeather();
    }
}
