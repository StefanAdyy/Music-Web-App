using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class PlaylistAlbumBL : IPlaylistAlbumBL
    {
        private readonly IPlaylistAlbumDataAccess _playlistAlbumDataAccess;
        public PlaylistAlbumBL(IPlaylistAlbumDataAccess playlistAlbumDataAccess)
        {
            _playlistAlbumDataAccess=playlistAlbumDataAccess ?? throw new ArgumentNullException("IPlaylistAlbumDataAccess cannot be null");
        }

        public void Create(PlaylistAlbum playlistAlbum)
        {
            _playlistAlbumDataAccess.Create(playlistAlbum);
        }

        public void Delete(int playlistAlbumId)
        {
            _playlistAlbumDataAccess.Delete(playlistAlbumId);
        }

        public List<PlaylistAlbum> Read()
        {
            return _playlistAlbumDataAccess.Read();
        }

        public PlaylistAlbum Read(int playlistAlbumId)
        {
            return _playlistAlbumDataAccess.Read(playlistAlbumId);
        }

        public void Update(PlaylistAlbum playlistAlbum)
        {
            _playlistAlbumDataAccess.Update(playlistAlbum);
        }
    }
}
