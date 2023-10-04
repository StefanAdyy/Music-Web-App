using Domain;
using System.Collections.Generic;

namespace BusinessLogic.Abstract
{
    public interface IPlaylistAlbumDataAccess
    {
        public void Create(PlaylistAlbum playlistAlbum);
        public List<PlaylistAlbum> Read();
        public PlaylistAlbum Read(int playlistAlbumId);
        public void Update(PlaylistAlbum playlistAlbum);
        public void Delete(int playlistAlbumId);
    }
}
