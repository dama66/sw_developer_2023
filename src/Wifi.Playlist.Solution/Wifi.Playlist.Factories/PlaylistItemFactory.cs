using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;
using Wifi.Playlist.Items;

namespace Wifi.Playlist.Factories
{
    public class PlaylistItemFactory : IPlaylistItemFactory
    {
        public IEnumerable<IFileInfo> AvailableTypes
        { get
            {
                return new IFileInfo[]
                {
                    new Mp3Item(string.Empty)
                };
            } 
        }

        public IPlaylistItem Create(string fileName)
        {
            IPlaylistItem item = null;

            var extension = Path.GetExtension(fileName);

            switch (extension)
            {
                case ".mp3":
                    item = new Mp3Item(fileName);
                    break;
            }
            return item;
        }
    }
}
