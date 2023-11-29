using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Playlist.Items.Test
{
    [TestFixture]
    public class Mp3ItemTests
    {
        [Test]
        [Ignore("Testmethod for debugging TagLib nuget")]
        public void TestMp3Item_class()
        {
            var mp3Item = new Mp3Item(@"C:\myCode\Repos\sw_developer_2023_trainer\DemoFiles\001 - Bruno Mars - Grenade.mp3");

            var title = mp3Item.Title;
        }
    }
}
