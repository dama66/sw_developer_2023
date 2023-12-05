using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System.IO;
using Wifi.Playlist.CoreTypes;
using System.IO.Abstractions;


namespace Wifi.Playlist.Repositories
{
    public class M3uRepository : IPlaylistRepository
    {
        public string Description => "M3U Repository";
        public string Extension => ".m3u";

        private IPlaylistItemFactory _playlistItemFactory;

        public M3uRepository(IPlaylistItemFactory playlistItemFactory)
        {
            _playlistItemFactory = playlistItemFactory;
        }


        public IPlaylist Load(string filePath)
        {
            StreamReader _streamReader = new StreamReader(filePath);
            M3uContent _content = new M3uContent();
            M3uPlaylist _m3uPlaylist = _content.GetFromStream(_streamReader.BaseStream);

            var _playlist = new CoreTypes.Playlist(Path.GetFileName(filePath).Replace("_"," ").Replace(".m3u",""), "MAERIDA");

            foreach (M3uPlaylistEntry _m3uPlaylistItem in _m3uPlaylist.PlaylistEntries)
            {

                 var newItem = _playlistItemFactory.Create(_m3uPlaylistItem.Path);
                

                if (newItem != null)
                {
                    _playlist.Add(newItem);
                }   
            }
            return _playlist;
        }

        public void Save(IPlaylist playlist, string filePath)
        {
            M3uPlaylist m3uPlaylist = new M3uPlaylist();
            m3uPlaylist.IsExtended = true;

            m3uPlaylist.Comments.Add($"#Title:{playlist.Name}");
            m3uPlaylist.Comments.Add($"#Author:{playlist.Author}");
            m3uPlaylist.Comments.Add($"#CreatedAt:{playlist.CreatedAt.ToShortDateString()}");

            foreach (IPlaylistItem item in playlist.Items)
            {
                m3uPlaylist.PlaylistEntries.Add(new M3uPlaylistEntry()
                {
                    Album = "Album",
                    AlbumArtist = item.Author,
                    Duration = item.Duration,
                    Path = item.FilePath,
                    Title = item.Title
                });
            }

            StreamWriter _streamWriter = new StreamWriter(filePath);

            _streamWriter.Write(PlaylistToTextHelper.ToText(m3uPlaylist));
            _streamWriter.Flush();
            _streamWriter.Close();
        }
    }
}
