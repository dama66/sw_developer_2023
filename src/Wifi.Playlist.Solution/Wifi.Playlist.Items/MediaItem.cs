using MimeTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;
using File = TagLib.File;

namespace Wifi.Playlist.Items
{
    public class MediaItem : IPlaylistItem
    {
        private readonly string _filePath;
        private readonly File _tagfile;

        public MediaItem(string filePath)
        {
            _filePath = filePath;
            _tagfile = TagLib.File.Create(_filePath);
        }

        public string Title => _tagfile.Tag.Title;

        public string Author => _tagfile.Tag.FirstPerformer;

        public TimeSpan Duration => _tagfile.Properties.Duration;

        public string FilePath => _filePath;

        public Image Thumbnail
        {
            get
            {
                Image image = null;

                if (_tagfile.Tag.Pictures != null && _tagfile.Tag.Pictures.Length > 0)
                {
                    //https://stackoverflow.com/questions/10247216/c-sharp-mp3-id-tags-with-taglib-album-art
                    image = Image.FromStream(new MemoryStream(_tagfile.Tag.Pictures[0].Data.Data));
                    image = image.GetThumbnailImage(128, 128, null, IntPtr.Zero);
                }

                return image;
            }
        }

        public string Description => _tagfile.Properties.Description;

        public string Extension => Path.GetExtension(_filePath);

           
    }
}
