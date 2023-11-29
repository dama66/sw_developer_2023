using System;
using System.Drawing;


namespace Wifi.Playlist.CoreTypes
{
    public interface IPlaylistItem : IFileInfo
    {
        string Title { get; }
        string Author { get; }
        TimeSpan Duration { get; }
        string FilePath { get; }
        Image Thumbnail { get; }
    }
}
