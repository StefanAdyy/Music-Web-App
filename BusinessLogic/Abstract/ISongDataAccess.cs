using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ISongDataAccess
    {
        public void Create(Song song);
        public List<Song> Read();
        public Song Read(int songId);
        public void Update(Song song);
        public void Delete(int songId);
        public void AddLike(int songId);
    }
}
