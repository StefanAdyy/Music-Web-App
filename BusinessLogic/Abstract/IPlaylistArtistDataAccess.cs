using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IPlaylistArtistDataAccess
    {
        public void Create(PlaylistArtist playlistArtist);
        public List<PlaylistArtist> Read();
        public PlaylistArtist Read(int playlistArtistId);
        public void Update(PlaylistArtist playlistArtist);
        public void Delete(int playlistArtistId);
    }
}
