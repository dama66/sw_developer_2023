using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Wifi.Playlist.CoreTypes
{
    public interface IPlaylistItemFactory
    {
        IEnumerable<IFileInfo> AvailableTypes { get; }

        IPlaylistItem Create(string fileName);
    }
}