using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class AlbumSongController : Controller
    {
        private readonly IAlbumSongBL _albumSongBL;
        private readonly IAlbumBL _albumBL;
        private readonly ISongBL _songBL;

        public AlbumSongController(IAlbumSongBL albumSongBL, IAlbumBL albumBL, ISongBL songBL)
        {
            _albumSongBL = albumSongBL;
            _albumBL = albumBL;
            _songBL = songBL;
        }

        public IActionResult Index()
        {
            return View(_albumSongBL.Read());
        }

        public IActionResult Create()
        {
            ViewBag.Albums = _albumBL.Read().Select(item => new SelectListItem { Value = item.AlbumId.ToString(), Text = item.Title + ", record label: " + item.RecordLabel + ", release date: " + item.ReleaseDate.ToShortDateString() });
            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title + ", release date: " + item.ReleaseDate.ToShortDateString() });
            return View();
        }

        [HttpPost]
        public IActionResult Create(AlbumSong albumSong)
        {
            if (ModelState.IsValid)
            {
                _albumSongBL.Create(albumSong);
            }
            else
            {
                ViewBag.Albums = _albumBL.Read().Select(item => new SelectListItem { Value = item.AlbumId.ToString(), Text = item.Title + ", record label: " + item.RecordLabel + ", release date: " + item.ReleaseDate.ToShortDateString() });
                ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title + ", release date: " + item.ReleaseDate.ToShortDateString() });
                return View(albumSong);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int albumSongId)
        {
            ViewBag.Albums = _albumBL.Read().Select(item => new SelectListItem { Value = item.AlbumId.ToString(), Text = item.Title + ", record label: " + item.RecordLabel + ", release date: " + item.ReleaseDate.ToShortDateString() });
            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title + ", release date: " + item.ReleaseDate.ToShortDateString() });
            return View(_albumSongBL.Read(albumSongId));
        }

        [HttpPost]
        public IActionResult Edit(AlbumSong albumSong)
        {
            if (ModelState.IsValid)
            {
                _albumSongBL.Update(albumSong);
            }
            else
            {
                return View(albumSong);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int albumSongId)
        {
            _albumSongBL.Delete(albumSongId);
            return RedirectToAction("Index");
        }
    }
}
