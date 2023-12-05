using System;
using System.Drawing;
using System.IO;
using TagLib;
using Wifi.Playlist.CoreTypes;
using static System.Net.Mime.MediaTypeNames;
using File = TagLib.File;

namespace Wifi.Playlist.Items
{
    /// <summary>
    /// Base Imageitem type for Playlist. 
    /// Supported image types: bmp, gif, jpeg, pbm, pgm, ppm, pnm, pcx, png, tiff, dng, svg    
    /// </summary>
    /// <see cref="https://github.com/mono/taglib-sharp"/>
    public abstract class PictureItemBase : IPlaylistItem
    {
        private readonly string _filePath;
        private readonly File _tagFile;
        private readonly string _extension;
        

        public PictureItemBase(string filePath, string extension)
        {
            _extension = extension;

            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }
            _filePath = filePath;
            _tagFile = TagLib.File.Create(filePath);
            
        }

        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(_tagFile.Tag.Title))
                {
                    return System.IO.Path.GetFileName(_filePath);
                }

                return _tagFile.Tag.Title;
            }
        }

        public string Author
        {
            get
            {
                if(string.IsNullOrEmpty(_tagFile.Tag.FirstPerformer))
                {
                    return "Unknown";
                }

                return _tagFile.Tag.FirstPerformer;
            }
        }
        

        public TimeSpan Duration => TimeSpan.FromSeconds(10);

        public string FilePath => _filePath;

        public System.Drawing.Image Thumbnail
        {
            get
            {
                var image = System.Drawing.Image.FromFile(_filePath);
                return image.GetThumbnailImage(128, 128, null, IntPtr.Zero);
            }
        }

        public string Description => $"{_extension.ToUpper().Replace(".", "")} picture file";

        public string Extension => _extension;

        public override string ToString()
        {
            return Path.GetFileNameWithoutExtension(_filePath);
        }
    }
}
