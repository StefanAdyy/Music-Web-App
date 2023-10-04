using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IAlbumDataAccess
    {
        public void Create(Album album);
        public List<Album> Read();
        public Album Read(int albumId);
        public void Update(Album album);
        public void Delete(int albumId);
    }
}
