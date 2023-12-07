using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Playlist.Repositories.json
{

    public class PlaylistEntity
    {
        public string name { get; set; }
        public string author { get; set; }
        public string createdAt { get; set; }
        public ItemEntity[] items { get; set; }
    }

}
