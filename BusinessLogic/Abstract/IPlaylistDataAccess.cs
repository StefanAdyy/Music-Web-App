using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IPlaylistDataAccess
    {
        public void Create(Playlist playlist);
        public List<Playlist> Read();
        public Playlist Read(int playlistId);
        public void Update(Playlist playlist);
        public void Delete(int playlistId);
        public Playlist GetLastAddedPlaylist();
    }
}
