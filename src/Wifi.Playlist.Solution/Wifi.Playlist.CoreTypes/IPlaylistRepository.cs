namespace Wifi.Playlist.CoreTypes
{
    public interface IPlaylistRepository : IFileInfo
    {
       void Save(IPlaylist playlist, string filePath);

        IPlaylist Load(string filePath);
    }
}
