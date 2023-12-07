using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;

namespace Wifi.Playlist.Repositories.json
{
    public static class MapperExtensions
    {
        public static PlaylistEntity ToEntity(this IPlaylist playlist)
        {
            return new PlaylistEntity()
            {
                author = playlist.Author,
                name = playlist.Name,
                createdAt = playlist.CreatedAt.ToShortDateString(),
                items = playlist.Items.ToEntity()
            };
        }

        public static ItemEntity[] ToEntity(this IEnumerable<IPlaylistItem> items)
        {
            var entities = new List<ItemEntity>(); 

            foreach (IPlaylistItem item in items)
            {
                entities.Add(new ItemEntity()
                {
                    filePath = item.FilePath,
                });
            }

            return entities.ToArray();
        }

        public static IPlaylist ToDomain(this PlaylistEntity playlistEntity, IPlaylistItemFactory playlistItemFactory)
        {
            var playlist = new CoreTypes.Playlist(playlistEntity.name, 
                                                 playlistEntity.author, 
                                                 DateTime.Parse(playlistEntity.createdAt));

            foreach ( var itemEntity in playlistEntity.items )
            {
                var item = playlistItemFactory.Create(itemEntity.filePath);
                if ( item != null )
                {
                    playlist.Add(item);
                }
            }

            return playlist;
        }
    }
}
