using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Wifi.Playlist.CoreTypes
{
    public interface IRepositoryFactory
    {
        IEnumerable<IFileInfo> AvailableTypes { get; }

        IPlaylistRepository Create(string fileName);
    }
}