using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wifi.Playlist.FormsUI
{
    public class DummyEditor : INewPlaylistDataProvider
    {
        public string PlaylistAuthor => "Max Musterman";

        public string PlaylistName => "My super charts 2010";

        public DialogResult ShowEditor()
        {
            return DialogResult.OK;
        }
    }
}
