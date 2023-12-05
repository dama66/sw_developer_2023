using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;
using PlaylistsNET;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using Wifi.Playlist.Factories;

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

            var _playlist = new CoreTypes.Playlist(Path.GetFileName(filePath).Replace("_"," ").Replace(".txt",""), "MAERIDA");

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
            M3uPlaylist _m3uPlaylist = new M3uPlaylist();
            _m3uPlaylist.IsExtended = true;

            foreach(IPlaylistItem item in playlist.Items)
            {
                _m3uPlaylist.PlaylistEntries.Add(new M3uPlaylistEntry()
                {
                    Album = "Album",
                    AlbumArtist = item.Author,
                    Duration = item.Duration,
                    Path = item.FilePath,
                    Title = item.Title
                });
            }

            StreamWriter _streamWriter = new StreamWriter(filePath);

            _streamWriter.Write(PlaylistToTextHelper.ToText(_m3uPlaylist));
            _streamWriter.Flush();
            _streamWriter.Close();
        }
    }
}
