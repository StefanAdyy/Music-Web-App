using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AlbumSongBL : IAlbumSongBL
    {
        private readonly IAlbumSongDataAccess _albumSongDataAccess;

        public AlbumSongBL(IAlbumSongDataAccess albumSongDataAccess)
        {
            _albumSongDataAccess=albumSongDataAccess ?? throw new ArgumentNullException("IAlbumSongDataAccess cannot be null");
        }

        public void Create(AlbumSong albumSong)
        {
            _albumSongDataAccess.Create(albumSong);
        }

        public void Delete(int albumSongId)
        {
            _albumSongDataAccess.Delete(albumSongId);
        }

        public List<AlbumSong> Read()
        {
            return _albumSongDataAccess.Read();
        }

        public AlbumSong Read(int albumSongId)
        {
            return _albumSongDataAccess.Read(albumSongId);
        }

        public void Update(AlbumSong albumSong)
        {
            _albumSongDataAccess.Update(albumSong);
        }
    }
}
