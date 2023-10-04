using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IPlaylistAlbumBL
    {
        public void Create(PlaylistAlbum playlistAlbum);
        public List<PlaylistAlbum> Read();
        public PlaylistAlbum Read(int playlistAlbumId);
        public void Update(PlaylistAlbum playlistAlbum);
        public void Delete(int playlistAlbumId);
    }
}
