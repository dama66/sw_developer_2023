using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Playlist.CoreTypes
{
    public interface IPlaylistRepository : IFileInfo
    {
        void Save(IPlaylist playlist, string filePath);

        IPlaylist Load(string filePath);
    }
}
