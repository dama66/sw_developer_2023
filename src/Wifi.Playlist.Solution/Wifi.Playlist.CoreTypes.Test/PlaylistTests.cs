using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Wifi.Playlist.CoreTypes.Test
{
    [TestFixture]
    public class PlaylistTests
    {
        private Playlist _fixture;

        [SetUp]
        public void init()
        {
           

            _fixture = new Playlist("Metal Charge", "David");

        }

        [Test]
        public void Name_get()
        {
            //Arrange
          
            //Act
            var erg = _fixture.Name;
            //Assert
            Assert.That(erg, Is.EqualTo("Metal Charge"));
        }

        [Test]
        public void Name_set()
        {
            //Arrange
            _fixture.Name = "SchlagerStars";
            //Act
            var erg = _fixture.Name;
            //Assert
            Assert.That(erg, Is.EqualTo("SchlagerStars"));
        }

        [Test]
        public void Duration_get()
        {
            //Arrange
            var item1 = new Mock<IPlaylistItem>();
            var item2 = new Mock<IPlaylistItem>();

            item1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(80));
            item2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(95));

            _fixture.Add(item1.Object);
            _fixture.Add(item2.Object);

            //Act
            var erg = _fixture.Duration;

            //Assert
            Assert.That(erg, Is.EqualTo(TimeSpan.FromSeconds(175)));
        }

        [Test]
        public void Duration_get_null()
        {
            //Arrange


            //Act
            var erg = _fixture.Duration;

            //Assert
            Assert.That(erg, Is.EqualTo(TimeSpan.Zero));
        }

        [Test]
        public void BaicTest()
        {
            //Arrange
            int zahl = 4;
            int erg = 0;

            //Act
            erg = zahl * 2;

            //Assert
            Assert.That(erg, Is.EqualTo(8));
        }
    }
}
