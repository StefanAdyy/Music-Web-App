using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PlaylistBL : IPlaylistBL
    {
        private readonly IPlaylistDataAccess _playlistDataAccess;
        public PlaylistBL(IPlaylistDataAccess playlistDataAccess)
        {
            _playlistDataAccess=playlistDataAccess ?? throw new ArgumentNullException("IPlaylistDataAccess cannot be null");
        }
        public void Create(Playlist playlist)
        {
            _playlistDataAccess.Create(playlist);
        }

        public void Delete(int playlistId)
        {
            _playlistDataAccess.Delete(playlistId);
        }

        public Playlist GetLastAddedPlaylist()
        {
            return _playlistDataAccess.GetLastAddedPlaylist();
        }

        public List<Playlist> Read()
        {
            return _playlistDataAccess.Read();
        }

        public Playlist Read(int playlistId)
        {
            return _playlistDataAccess.Read(playlistId);
        }

        public void Update(Playlist playlist)
        {
            _playlistDataAccess.Update(playlist);
        }
    }
}
