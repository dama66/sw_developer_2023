using System.Collections.Generic;

namespace Wifi.Playlist.CoreTypes
{
    public interface IRepositoryFactory
    {
        IEnumerable<IFileInfo> AvailableTypes { get; }

        IPlaylistRepository Create(string fileName);
    }
}