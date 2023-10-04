using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SongArtistBL:ISongArtistBL
    {
        private readonly ISongArtistDataAccess _songArtistDataAccess;

        public SongArtistBL(ISongArtistDataAccess songArtistDataAccess)
        {
            _songArtistDataAccess = songArtistDataAccess ?? throw new ArgumentNullException("ISongArtistDataAccess cannot be null.");
        }
        public void Create(SongArtist songArtist)
        {
            _songArtistDataAccess.Create(songArtist);
        }

        public void Delete(int songArtistId)
        {
            _songArtistDataAccess.Delete(songArtistId);
        }

        public List<SongArtist> Read()
        {
            return _songArtistDataAccess.Read();
        }

        public SongArtist Read(int songArtistId)
        {
            return _songArtistDataAccess.Read(songArtistId);
        }

        public void Update(SongArtist songArtist)
        {
            _songArtistDataAccess.Update(songArtist);
        }
    }
}
