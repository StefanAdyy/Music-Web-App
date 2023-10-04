using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PlaylistSongBL : IPlaylistSongBL
    {
        private readonly IPlaylistSongDataAccess _playlistSongDataAccess;
        public PlaylistSongBL(IPlaylistSongDataAccess playlistSongDataAccess)
        {
            _playlistSongDataAccess = playlistSongDataAccess ?? throw new ArgumentNullException("IPlaylistSongDataAccess cannot be null.");
        }

        public void AddSongsFromAlbum(int playlistId, int albumId)
        {
            _playlistSongDataAccess.AddSongsFromAlbum(playlistId, albumId);
        }

        public void AddSongsFromArtist(int playlistId, int artistId)
        {
            _playlistSongDataAccess.AddSongsFromArtist(playlistId, artistId);
        }

        public void Create(PlaylistSong playlistSong)
        {
            _playlistSongDataAccess.Create(playlistSong);
        }

        public void Delete(int playlistSongId)
        {
            _playlistSongDataAccess.Delete(playlistSongId);
        }

        public List<PlaylistSong> Read()
        {
            return _playlistSongDataAccess.Read();
        }

        public PlaylistSong Read(int playlistSongId)
        {
            return _playlistSongDataAccess.Read(playlistSongId);
        }

        public List<PlaylistSong> ReadByPlaylistId(int playlistId)
        {
            return _playlistSongDataAccess.ReadByPlaylistId(playlistId);
        }

        public void Update(PlaylistSong playlistSong)
        {
            _playlistSongDataAccess.Update(playlistSong);
        }
    }
}
