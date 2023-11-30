using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Playlist.Items.Test
{
    [TestFixture]
    public class MediaItemTest
    {
        [Test]
        //[Ignore("Testmethod for debugging TagLib nuget")]
        public void TestPictureItem_class()
        {
            var mediaItem = new MediaItem(@"C:\Users\maierda\source\repos\sw_developer_2023\doc\images\Logo.png");

            var title = mediaItem.Title;

            var extension = mediaItem.Extension;

            var description = mediaItem.Description;
        }
    }
}
