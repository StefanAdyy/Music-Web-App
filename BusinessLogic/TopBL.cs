using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TopBL : ITopBL
    {
        private readonly ITopDataAccess _topDataAccess;
        public TopBL(ITopDataAccess topDataAccess)
        {
            _topDataAccess=topDataAccess;
        }

        public List<Top> ReadFavouriteAlbums()
        {
            return _topDataAccess.ReadFavouriteAlbums();
        }

        public List<Top> ReadFavouriteArtists()
        {
            return _topDataAccess.ReadFavouriteArtists();
        }

        public List<Top> ReadFavouriteGenres()
        {
            return _topDataAccess.ReadFavouriteGenres();
        }

        public List<Top> ReadFavouriteSongs()
        {
            return _topDataAccess.ReadFavouriteSongs();
        }

        public List<Top> ReadMostLikedSongPerAlbum()
        {
            return _topDataAccess.ReadMostLikedSongPerAlbum();
        }

        public List<Top> ReadMostLikedSongPerArtist()
        {
            return _topDataAccess.ReadMostLikedSongPerArtist();
        }

        public List<Top> ReadMostLikedSongPerGenre()
        {
            return _topDataAccess.ReadMostLikedSongPerGenre();
        }
    }
}
