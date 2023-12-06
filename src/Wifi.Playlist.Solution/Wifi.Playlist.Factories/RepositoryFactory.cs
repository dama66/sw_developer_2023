using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;
using Wifi.Playlist.Repositories;

namespace Wifi.Playlist.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private IPlaylistItemFactory _itemFactory;

        public RepositoryFactory(IPlaylistItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
        }

        public IEnumerable<IFileInfo> AvailableTypes => new IFileInfo[] 
        {   
            new M3uRepository(null)
        };

        public IPlaylistRepository Create(string fileName)
        {
            IPlaylistRepository repository = null;

            if (string.IsNullOrEmpty(fileName))
            {
                return repository;
            }

            var ext = Path.GetExtension(fileName);

            switch (ext)
            {
                case ".m3u":
                    repository = new M3uRepository(_itemFactory);
                    break;
                
                //hier kommen dann weitere typen hinzu...
            }

            return repository;
        }
    }
}
