using System.Collections.Generic;

namespace Wifi.Playlist.CoreTypes
{
    public interface IPlaylistItemFactory
    {
        IEnumerable<IFileInfo> AvailableTypes { get; }

        IPlaylistItem Create(string fileName);
    }
}