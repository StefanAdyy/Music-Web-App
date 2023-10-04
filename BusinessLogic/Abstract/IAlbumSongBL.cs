using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IAlbumSongBL
    {
        public void Create(AlbumSong albumSong);
        public List<AlbumSong> Read();
        public AlbumSong Read(int albumSongId);
        public void Update(AlbumSong albumSong);
        public void Delete(int albumSongId);
    }
}
