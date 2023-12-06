using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;

namespace Wifi.Playlist.Repositories.Test
{
    [TestFixture]
    public class M3uRepositoryTests
    {
        private M3uRepository _fixture;
       // private MockFileSystem _mockFileSystem;
        private Mock<IFileSystem> _mockedFileSystem;
        private Mock<IPlaylist> _mockedPlaylist;
        private Mock<IPlaylistItemFactory> _mockedPlaylistFactory;

        [SetUp]
        public void Init()
        {
            _mockedFileSystem = new Mock<IFileSystem>();

            var playlistItem1 = new Mock<IPlaylistItem>();
            playlistItem1.Setup(x => x.Title).Returns("Song title 1");
            playlistItem1.Setup(x => x.Author).Returns("Super singer 1");
            playlistItem1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(15));
            playlistItem1.Setup(x => x.FilePath).Returns("song1.mp3");

            var playlistItem2 = new Mock<IPlaylistItem>();
            playlistItem2.Setup(x => x.Title).Returns("Song title 2");
            playlistItem2.Setup(x => x.Author).Returns("Super singer 2");
            playlistItem2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(25));
            playlistItem2.Setup(x => x.FilePath).Returns("song2.mp3");

            _mockedPlaylist = new Mock<IPlaylist>();
            _mockedPlaylist.Setup(x => x.Name).Returns("My super charts 2022");
            _mockedPlaylist.Setup(x => x.Author).Returns("Gandalf");
            _mockedPlaylist.Setup(x => x.CreatedAt).Returns(DateTime.Now);
            _mockedPlaylist.Setup(x => x.Items).Returns(new IPlaylistItem[] { playlistItem1.Object, playlistItem2.Object });

            _fixture = new M3uRepository(_mockedPlaylistFactory.Object);
        }

        [Test]
        public void Load()
        {
            _fixture = new M3uRepository(_mockedPlaylistFactory.Object);

            var playlist = _fixture.Load(@"C:\Users\User\Desktop\atilla.m3u");

        }

        [Test]
        public void Save()
        {
            //arrange
            string createdContent = string.Empty;
            string referenceContent = "#EXTM3U\r\n##Title:My super charts 2022\r\n##Author:Gandalf\r\n##CreatedAt:05.12.2023\r\n#EXTART:Super singer 1\r\n#EXTINF:15,Song title 1\r\nsong1.mp3\r\n#EXTART:Super singer 2\r\n#EXTINF:25,Song title 2\r\nsong2.mp3";

            var mockedFile = new Mock<IFile>();
            mockedFile.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>()))
                      .Callback<string, string>((path, content) =>
                      {
                          createdContent = content;
                      });

            _mockedFileSystem.Setup(x => x.File).Returns(mockedFile.Object);

            //act
            _fixture.Save(_mockedPlaylist.Object, @"c:\myMusic\myPlaylist.m3u");

            //assert
            Assert.That(createdContent, Is.EqualTo(referenceContent));
        }

        [Test]
        public void Save_PlaylistIsNull()
        {
            //arrange            

            //act
            _fixture.Save(null, @"c:\myMusic\myPlaylist.m3u");

            //assert            
            _mockedFileSystem.Verify(x => x.File.WriteAllText(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}
