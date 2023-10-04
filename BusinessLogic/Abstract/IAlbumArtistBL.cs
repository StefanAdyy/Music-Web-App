using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IAlbumArtistBL
    {
        public void Create(AlbumArtist albumArtist);
        public List<AlbumArtist> Read();
        public List<AlbumArtist> ReadByAlbumId(int albumId);
        public List<AlbumArtist> ReadByArtistId(int artistId);
        public AlbumArtist Read(int albumArtistId);
        public void Update(AlbumArtist albumArtist);
        public void Delete(int albumArtistId);
    }
}
