using Moq;
using NUnit.Framework;
using System;
using System.Linq;


namespace Wifi.Playlist.CoreTypes.Test
{
    [TestFixture]
    public class PlaylistTests
    {
        private Playlist _fixture;        

        [SetUp]
        public void Init()
        {            
            _fixture = new Playlist("TopHits 2023", "Gandalf");            
        }


        [Test]
        public void Name_get()
        {
            //Arrange            

            //Act
            var erg = _fixture.Name;

            //Assert
            Assert.That(erg, Is.EqualTo("TopHits 2023"));
        }

        [Test]
        public void CreateAt_get()
        {
            //Arrange            

            //Act
            var erg = _fixture.CreatedAt;

            //Assert
            Assert.That(erg.Date, Is.EqualTo(DateTime.Now.Date));
        }

        [Test]
        public void Author_get()
        {
            //Arrange            

            //Act
            var erg = _fixture.Author;

            //Assert
            Assert.That(erg, Is.EqualTo("Gandalf"));
        }

        [Test]
        public void Items_get()
        {
            //Arrange            
            var item1 = new Mock<IPlaylistItem>();
            var item2 = new Mock<IPlaylistItem>();

            _fixture.Add(item1.Object);
            _fixture.Add(item2.Object);

            //Act
            var erg = _fixture.Items;

            //Assert
            Assert.That(erg.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Author_set()
        {
            //Arrange            
            _fixture.Author = "Max Mustermann";

            //Act
            var erg = _fixture.Author;

            //Assert
            Assert.That(erg, Is.EqualTo("Max Mustermann"));
        }

        [Test]
        public void Name_set()
        {
            //Arrange            
            _fixture.Name = "My SuperHits 1980";

            //Act
            var erg = _fixture.Name;

            //Assert
            Assert.That(erg, Is.EqualTo("My SuperHits 1980"));
        }

        [Test]
        public void Duration_get()
        {
            //Arrange
            var item1 = new Mock<IPlaylistItem>();
            var item2 = new Mock<IPlaylistItem>();

            item1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(80));
            item2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(200));

            _fixture.Add(item1.Object);
            _fixture.Add(item2.Object);

            //Act
            var duration = _fixture.Duration;

            //Assert
            Assert.That(duration, Is.EqualTo(TimeSpan.FromSeconds(280)));
        }

        [Test]
        public void Duration_get_NoItems()
        {
            //Arrange           

            //Act
            var duration = _fixture.Duration;

            //Assert
            Assert.That(duration, Is.EqualTo(TimeSpan.Zero));
        }

        [Test]
        public void Add()
        {
            //arrange
            var item1 = new Mock<IPlaylistItem>();
           
            item1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(80));
            item1.Setup(x => x.Author).Returns("Gandi");
            item1.Setup(x => x.Title).Returns("MyMusic");

            //act
            _fixture.Add(item1.Object);

            //assert
            Assert.That(_fixture.Items.Count, Is.EqualTo(1));
            //or
            //var addedItem = _fixture.Items.FirstOrDefault();
            //Assert.That(addedItem.Title, Is.EqualTo("MyMusic"));
            //Assert.That(addedItem.Author, Is.EqualTo("Gandi"));
        }

        [Test]
        public void Add_NullItem()
        {
            //arrange            

            //act
            _fixture.Add(null);

            //assert
            Assert.That(_fixture.Items.Count, Is.EqualTo(0));
        }


        [Test]
        public void Remove()
        {
            //arrange
            var item1 = new Mock<IPlaylistItem>();
            var item2 = new Mock<IPlaylistItem>();

            item1.Setup(x => x.Title).Returns("Test Item 1");
            item2.Setup(x => x.Title).Returns("Test Item 2");

            _fixture.Add(item1.Object);
            _fixture.Add(item2.Object);

            //act
            _fixture.Remove(item1.Object);

            //assert
            Assert.That(_fixture.Items.Count, Is.EqualTo(1));
            Assert.That(_fixture.Items.FirstOrDefault().Title, Is.EqualTo("Test Item 2"));
        }

        [Test]
        public void Remove_ItemNull()
        {
            //arrange
            var item1 = new Mock<IPlaylistItem>();
            var item2 = new Mock<IPlaylistItem>();

            item1.Setup(x => x.Title).Returns("Test Item 1");
            item2.Setup(x => x.Title).Returns("Test Item 2");

            _fixture.Add(item1.Object);
            _fixture.Add(item2.Object);

            //act
            _fixture.Remove(null);

            //assert
            Assert.That(_fixture.Items.Count, Is.EqualTo(2));            
        }

        [Test]
        public void Clear()
        {
            //arrange
            var item1 = new Mock<IPlaylistItem>();
            var item2 = new Mock<IPlaylistItem>();

            item1.Setup(x => x.Title).Returns("Test Item 1");
            item2.Setup(x => x.Title).Returns("Test Item 2");

            _fixture.Add(item1.Object);
            _fixture.Add(item2.Object);

            //act
            _fixture.Clear();

            //assert
            Assert.That(_fixture.Items.Count, Is.EqualTo(0));
        }

        [Test]
        [Ignore("This test was only for indrodution to unit tests")]
        public void BasicTest()
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
