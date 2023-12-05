using System;
using System.Drawing;
using System.IO;
using TagLib;
using Wifi.Playlist.CoreTypes;
using File = TagLib.File;

namespace Wifi.Playlist.Items
{
    public class Mp3Item : IPlaylistItem
    {
        private readonly string _filePath;
        private readonly File _tagfile;

        public Mp3Item(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

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

                if(_tagfile.Tag.Pictures != null && _tagfile.Tag.Pictures.Length > 0)
                {                    
                    //https://stackoverflow.com/questions/10247216/c-sharp-mp3-id-tags-with-taglib-album-art
                    image = Image.FromStream(new MemoryStream(_tagfile.Tag.Pictures[0].Data.Data));  
                    image = image.GetThumbnailImage(128,128, null, IntPtr.Zero);
                }

                return image;
            }
        }

        public string Description => "MP3 music file";

        public string Extension => ".mp3";

        public override string ToString()
        {
            return $"{Title} [{Author}]";
        }
    }
}
