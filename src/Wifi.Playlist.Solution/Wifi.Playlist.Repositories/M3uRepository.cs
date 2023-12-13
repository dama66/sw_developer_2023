using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using Wifi.Playlist.CoreTypes;

namespace Wifi.Playlist.Repositories
{
    public class M3uRepository : IPlaylistRepository
    {
        private readonly IFileSystem _fileSystem;
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public M3uRepository(IPlaylistItemFactory playlistItemFactory) 
            : this(playlistItemFactory, new FileSystem())
        {           
        }

        public M3uRepository(IPlaylistItemFactory playlistItemFactory, IFileSystem fileSystem)
        {
            _playlistItemFactory = playlistItemFactory;
            _fileSystem = fileSystem;
        }


        public string Description => "M3U Playlist format";

        public string Extension => ".m3u";

        public IPlaylist Load(string filePath)
        {
            string title = string.Empty;
            string author = string.Empty;
            string createAt = string.Empty;

            IPlaylist domainPlaylist = null;

            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            var stream = _fileSystem.File.OpenRead(filePath);

            var content = new M3uContent();
            var playlistEntity = content.GetFromStream(stream);

            //read meta data first
            foreach (var entry in playlistEntity.PlaylistEntries)
            {
                if (entry.Comments.Count > 0)
                {
                    title = GetCommentValue(entry.Comments, "#Title:");
                    author = GetCommentValue(entry.Comments, "#Author:");
                    createAt = GetCommentValue(entry.Comments, "#CreatedAt:");

                    break;
                }
            }

            domainPlaylist = new CoreTypes.Playlist(title, author, DateTime.Parse(createAt));
            foreach (var entry in playlistEntity.PlaylistEntries)
            {
                var playlistItem = _playlistItemFactory.Create(entry.Path);
                if (playlistItem != null)
                {
                    domainPlaylist.Add(playlistItem);
                }
            }

            return domainPlaylist;
        }
      
        public void Save(IPlaylist playlist, string filePath)
        {
            if (playlist == null)
            {
                return;
            }

            var m3uPlaylist = new M3uPlaylist();
            m3uPlaylist.IsExtended = true;

            m3uPlaylist.Comments.Add($"#Title:{playlist.Name}");
            m3uPlaylist.Comments.Add($"#Author:{playlist.Author}");
            m3uPlaylist.Comments.Add($"#CreatedAt:{playlist.CreatedAt.ToShortDateString()}");

            foreach (var item in playlist.Items)
            {
                var entityItem = new M3uPlaylistEntry()
                {
                    AlbumArtist = item.Author,
                    Duration = item.Duration,
                    Path = item.FilePath,
                    Title = item.Title
                };

                m3uPlaylist.PlaylistEntries.Add(entityItem);
            }

            //var content = new M3uContent();
            //string text = content.ToText(m3uPlaylist);
            var text = PlaylistToTextHelper.ToText(m3uPlaylist);

            _fileSystem.File.WriteAllText(filePath, text);
        }


        private string GetCommentValue(IEnumerable<string> commentList, string valueKey)
        {
            var valueLine = commentList.Where(x => x.StartsWith(valueKey))
                                   .FirstOrDefault();

            return valueLine.Replace(valueKey, string.Empty);
        }
    }
}
