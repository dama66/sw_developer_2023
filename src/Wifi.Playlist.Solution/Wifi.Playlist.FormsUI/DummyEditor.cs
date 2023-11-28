using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wifi.Playlist.FormsUI
{
    internal class DummyEditor : INewPlaylistDataProvider
    {
        public string PlaylistName => "My Playlist";

        public string PlaylistAuthor => "Max Mustermann";

        public DialogResult ShowEditor()
        {
            return DialogResult.OK;
        }
    }
}
