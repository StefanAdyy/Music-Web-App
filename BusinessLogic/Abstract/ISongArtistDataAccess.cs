using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ISongArtistDataAccess
    {
        public void Create(SongArtist songArtist);
        public List<SongArtist> Read();
        public SongArtist Read(int singArtistId);
        public void Update(SongArtist songArtist);
        public void Delete(int songArtistId);
    }
}
