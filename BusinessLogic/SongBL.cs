using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SongBL : ISongBL
    {
        private readonly ISongDataAccess _songDataAccess;

        public SongBL(ISongDataAccess songDataAccess)
        {
            _songDataAccess=songDataAccess ?? throw new ArgumentNullException("ISongDataAccess cannot be null.");
        }
        public void Create(Song song)
        {
            _songDataAccess.Create(song);
        }

        public void Delete(int songId)
        {
            _songDataAccess.Delete(songId);
        }

        public List<Song> Read()
        {
            return _songDataAccess.Read();
        }

        public Song Read(int songId)
        {
            return _songDataAccess.Read(songId);
        }

        public void Update(Song song)
        {
            _songDataAccess.Update(song);
        }

        public void AddLike(int songId)
        {
            _songDataAccess.AddLike(songId);
        }
    }
}
