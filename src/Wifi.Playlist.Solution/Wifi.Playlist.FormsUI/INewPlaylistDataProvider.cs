using System.Windows.Forms;

namespace Wifi.Playlist.FormsUI
{
    public interface INewPlaylistDataProvider
    {
        string PlaylistName { get; }
        string PlaylistAuthor { get; }

        DialogResult ShowEditor();

    }
}
