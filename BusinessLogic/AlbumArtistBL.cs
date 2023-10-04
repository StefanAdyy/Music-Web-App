using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AlbumArtistBL : IAlbumArtistBL
    {
        private readonly IAlbumArtistDataAccess _albumArtistDataAccess;
        public AlbumArtistBL(IAlbumArtistDataAccess albumArtistDataAccess)
        {
            _albumArtistDataAccess=albumArtistDataAccess ?? throw new ArgumentNullException("IAlbumArtistDataAccess cannot be null");
        }
        public void Create(AlbumArtist albumArtist)
        {
            _albumArtistDataAccess.Create(albumArtist);
        }

        public void Delete(int albumArtistId)
        {
            _albumArtistDataAccess.Delete(albumArtistId);
        }

        public List<AlbumArtist> Read()
        {
            return _albumArtistDataAccess.Read();
        }

        public AlbumArtist Read(int albumArtistId)
        {
            return _albumArtistDataAccess.Read(albumArtistId);
        }

        public List<AlbumArtist> ReadByAlbumId(int albumId)
        {
            return _albumArtistDataAccess.ReadByAlbumId(albumId);
        }

        public List<AlbumArtist> ReadByArtistId(int artistId)
        {
            return _albumArtistDataAccess.ReadByArtistId(artistId);
        }

        public void Update(AlbumArtist albumArtist)
        {
            _albumArtistDataAccess.Update(albumArtist);
        }
    }
}
