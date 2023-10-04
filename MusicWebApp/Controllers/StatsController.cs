using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MusicWebApp.Controllers
{
    public class StatsController : Controller
    {
        private readonly IEntryDateBL _entryDateBL;
        private readonly ITopBL _topBL;
        public StatsController(IEntryDateBL entryDateBL, ITopBL topBL)
        {
            _entryDateBL = entryDateBL;
            _topBL = topBL; 
        }

        public IActionResult Index()
        {
            ViewBag.Minutes = _entryDateBL.CountMinutes();
            ViewBag.AverageTime =_entryDateBL.DailyAverageTime();
            return View();
        }

        public IActionResult FavouriteSongs()
        {
            return View(_topBL.ReadFavouriteSongs());
        }

        public IActionResult FavouriteArtists()
        {
            return View(_topBL.ReadFavouriteArtists());
        }

        public IActionResult FavouriteAlbums()
        {
            return View(_topBL.ReadFavouriteAlbums());
        }

        public IActionResult FavouriteGenres()
        {
            return View(_topBL.ReadFavouriteGenres());
        }
        public IActionResult MostLikedSongPerGenre()
        {
            return View(_topBL.ReadMostLikedSongPerGenre());
        }

        public IActionResult MostLikedSongPerArtist()
        {
            return View(_topBL.ReadMostLikedSongPerArtist());
        }

        public IActionResult MostLikedSongPerAlbum()
        {
            return View(_topBL.ReadMostLikedSongPerAlbum());
        }
    }
}
