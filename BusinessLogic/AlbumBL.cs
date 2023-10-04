using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AlbumBL : IAlbumBL
    {
        private readonly IAlbumDataAccess _albumDataAccess;
        public AlbumBL(IAlbumDataAccess albumDataAccess)
        {
            _albumDataAccess = albumDataAccess ?? throw new ArgumentNullException("IAlbumDataAccess cannot be null");
        }
        public void Create(Album album)
        {
            _albumDataAccess.Create(album);
        }

        public void Delete(int albumId)
        {
            _albumDataAccess.Delete(albumId);
        }

        public List<Album> Read()
        {
            return _albumDataAccess.Read();
        }

        public Album Read(int albumId)
        {
            return _albumDataAccess.Read(albumId);
        }

        public void Update(Album album)
        {
            _albumDataAccess.Update(album);
        }
    }
}
