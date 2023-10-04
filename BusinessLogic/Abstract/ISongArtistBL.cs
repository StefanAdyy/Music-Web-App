using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ISongArtistBL
    {
        public void Create(SongArtist songArtist);
        public List<SongArtist> Read();
        public SongArtist Read(int songArtistId);
        public void Update(SongArtist songArtist);
        public void Delete(int songArtistId);
    }
}
