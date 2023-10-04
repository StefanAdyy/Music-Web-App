using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MusicGenreBL : IMusicGenreBL
    {
        private readonly IMusicGenreDataAccess _musicGenreDataAccess;
        public MusicGenreBL(IMusicGenreDataAccess musicGenreDataAccess)
        {
            _musicGenreDataAccess = musicGenreDataAccess ?? throw new ArgumentNullException("IMusicTypeDataAccess cannot be null.");
        }
        public void Create(MusicGenre musicType)
        {
            _musicGenreDataAccess.Create(musicType);
        }

        public void Delete(int musicGenreId)
        {
            _musicGenreDataAccess.Delete(musicGenreId);
        }

        public List<MusicGenre> Read()
        {
            return _musicGenreDataAccess.Read();
        }

        public MusicGenre Read(int musicGenreId)
        {
            return _musicGenreDataAccess.Read(musicGenreId);
        }

        public void Update(MusicGenre musicGenre)
        {
            _musicGenreDataAccess.Update(musicGenre);
        }
    }
}
