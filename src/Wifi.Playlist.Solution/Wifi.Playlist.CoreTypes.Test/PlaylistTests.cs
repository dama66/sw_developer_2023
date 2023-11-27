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
        private Playlist _fixture2;

        [SetUp]
        public void init()
        {
            _fixture = new Playlist("Metal Charge", "David", new DateTime(2023, 11, 24, 11, 11, 11));
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
        public void Authot_get()
        {
            //Arrange

            //Act
            var erg = _fixture.Author;
            //Assert
            Assert.That(erg, Is.EqualTo("David"));
        }

        [Test]
        public void Author_set()
        {
            //Arrange
            _fixture.Author = "Alex";
            //Act
            var erg = _fixture.Author;
            //Assert
            Assert.That(erg, Is.EqualTo("Alex"));
        }

        [Test]
        public void CreatedAt_get()
        {
            //Arrange

            //Act
            var erg = _fixture.CreatedAt;
            //Assert
            Assert.That(erg, Is.EqualTo(new DateTime(2023, 11, 24, 11, 11, 11)));
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

        [Test]
        public void Item_Add()
        {
            //Arrange
            var item1 = new Mock<IPlaylistItem>();

            //Act
            _fixture.Add(item1.Object);

            //Assert
            Assert.That(item1.Object, Is.EqualTo(_fixture.Items.Last()));
        }

        [Test]
        public void Item_Remove()
        {
            //Arrange
            var item1 = new Mock<IPlaylistItem>();
            var item2 = new Mock<IPlaylistItem>();
            _fixture.Add(item1.Object);
            _fixture.Add(item2.Object);
            //Act
            _fixture.Remove(item2.Object);

            //Assert
            Assert.That(item1.Object, Is.EqualTo(_fixture.Items.Last()));
        }

        [Test]
        public void Item_Clear()
        {
            //Arrange
            _fixture2 = new Playlist("", "");

            var item1 = new Mock<IPlaylistItem>();
            _fixture.Add(item1.Object);

            //Act
            _fixture.Clear();

            //Assert
            Assert.That(_fixture.Items, Is.EqualTo(_fixture2.Items));
        }
    }
}
