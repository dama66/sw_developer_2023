using System.Drawing;
using System.Threading.Tasks;

namespace Wifi.Playlist.CoreTypes
{
    public interface ICurrentWeatherService
    {
        string Description { get; }
        string LocationName { get; }
        double Temperatur { get; }
        Image Thumbnail { get; }

        Task<bool> SetGeoLocationAsync(string city, string countryCode);
        Task<bool> UpdateCurrentWeatherAsync();

        //Task<bool> UpdateCurrentWeatherAsync(string city, string countryCode);
    }
}