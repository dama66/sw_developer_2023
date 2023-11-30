using System;
using System.Collections.Generic;

namespace Wifi.Playlist.CoreTypes
{
    public interface IPlaylist
    {
        string Author { get; set; }
        DateTime CreatedAt { get; }
        TimeSpan Duration { get; }
        IEnumerable<IPlaylistItem> Items { get; }
        string Name { get; set; }

        void Add(IPlaylistItem item);
        void Clear();
        void Remove(IPlaylistItem item);
    }
}