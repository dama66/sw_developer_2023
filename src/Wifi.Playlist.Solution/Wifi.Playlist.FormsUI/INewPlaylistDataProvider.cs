using System.Windows.Forms;

namespace Wifi.Playlist.FormsUI
{
    public interface INewPlaylistDataProvider
    {
        string PlaylistAuthor { get; }

        string PlaylistName { get; }

        DialogResult ShowEditor();
    }
}
