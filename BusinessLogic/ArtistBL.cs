using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ArtistBL:IArtistBL
    {
        private readonly IArtistDataAccess _artistDataAccess;

        public ArtistBL(IArtistDataAccess artistDataAccess)
        {
            _artistDataAccess = artistDataAccess ?? throw new ArgumentNullException("IArtistDataAccess cannot be null");
        }

        public void Create(Artist artist)
        {
            _artistDataAccess.Create(artist);
        }

        public void Delete(int artistId)
        {
            _artistDataAccess.Delete(artistId);
        }

        public List<Artist>Read()
        {
            return _artistDataAccess.Read();
        }

        public Artist Read(int artistId)
        {
            return _artistDataAccess.Read(artistId);
        }

        public void Update(Artist artist)
        {
            _artistDataAccess.Update(artist);
        }
    }
}
