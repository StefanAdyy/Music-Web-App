using Domain;
using System.Collections.Generic;

namespace BusinessLogic.Abstract
{
    public interface IPlaylistSongDataAccess
    {
        public void Create(PlaylistSong playlistSong);
        public List<PlaylistSong> Read();
        public PlaylistSong Read(int playlistSongId);
        public List<PlaylistSong> ReadByPlaylistId(int playlistId);
        public void Update(PlaylistSong playlistSong);
        public void Delete(int playlistSongId);
        public void AddSongsFromArtist(int playlistId, int artistId);
        public void AddSongsFromAlbum(int playlistId, int albumId);
    }
}
