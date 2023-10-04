using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IMusicGenreDataAccess
    {
        public void Create(MusicGenre musicGenre);
        public List<MusicGenre> Read();
        public MusicGenre Read(int musicGenreId);
        public void Update(MusicGenre musicGenre);
        public void Delete(int musicGenreId);
    }
}
