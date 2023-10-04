using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PlaylistArtistBL : IPlaylistArtistBL
    {
        private readonly IPlaylistArtistDataAccess _playlistArtistDataAccess;
        public PlaylistArtistBL(IPlaylistArtistDataAccess playlistArtistDataAccess)
        {
            _playlistArtistDataAccess=playlistArtistDataAccess ?? throw new ArgumentNullException("IPlaylistArtistDataAccess cannot be null");
        }

        public void Create(PlaylistArtist playlistArtist)
        {
            _playlistArtistDataAccess.Create(playlistArtist);
        }

        public void Delete(int playlistArtistId)
        {
            _playlistArtistDataAccess.Delete(playlistArtistId);
        }

        public List<PlaylistArtist> Read()
        {
            return _playlistArtistDataAccess.Read();
        }

        public PlaylistArtist Read(int playlistArtistId)
        {
            return _playlistArtistDataAccess.Read(playlistArtistId);
        }

        public void Update(PlaylistArtist playlistArtist)
        {
            _playlistArtistDataAccess.Update(playlistArtist);
        }
    }
}
