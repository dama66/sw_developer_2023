using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;

namespace Wifi.Playlist.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IEnumerable<IFileInfo> AvailableTypes => new IFileInfo[]
        {
           
        };

        public IPlaylistRepository Create(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
