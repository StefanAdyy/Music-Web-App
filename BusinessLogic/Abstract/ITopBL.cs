using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ITopBL
    {
        public List<Top> ReadMostLikedSongPerGenre();
        public List<Top> ReadMostLikedSongPerAlbum();
        public List<Top> ReadMostLikedSongPerArtist();
        public List<Top> ReadFavouriteSongs();
        public List<Top> ReadFavouriteGenres();
        public List<Top> ReadFavouriteAlbums();
        public List<Top> ReadFavouriteArtists();
    }
}
