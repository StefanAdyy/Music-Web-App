using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongBL _songBL;
        private readonly IMusicGenreBL _musicGenreBL;

        public SongController(ISongBL songBL, IMusicGenreBL musicGenreBL)
        {
            _songBL=songBL;
            _musicGenreBL=musicGenreBL;
        }

        public IActionResult Index()
        {
            return View(_songBL.Read());
        }

        public IActionResult Create()
        {
            ViewBag.MusicGenres = _musicGenreBL.Read().Select(item => new SelectListItem { Value = item.MusicGenreId.ToString(), Text = item.Genre });
            return View();
        }

        [HttpPost]
        public IActionResult Create(Song song)
        {
            if (ModelState.IsValid)
            {
                _songBL.Create(song);
            }
            else
            {
                ViewBag.MusicGenres = _musicGenreBL.Read().Select(item => new SelectListItem { Value = item.MusicGenreId.ToString(), Text = item.Genre });
                return View(song);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int songId)
        {
            ViewBag.MusicGenres = _musicGenreBL.Read().Select(item => new SelectListItem { Value = item.MusicGenreId.ToString(), Text = item.Genre });
            return View(_songBL.Read(songId));  
        }

        [HttpPost]
        public IActionResult Edit(Song song)
        {
            if (ModelState.IsValid)
            {
                _songBL.Update(song);
            }
            else
            {
                ViewBag.MusicGenres = _musicGenreBL.Read().Select(item => new SelectListItem { Value = item.MusicGenreId.ToString(), Text = item.Genre });
                return View(song);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int songId)
        {
            _songBL.Delete(songId);
            return RedirectToAction("Index");   
        }

        public IActionResult Like(int songId)
        {
            _songBL.AddLike(songId);
            return RedirectToAction("Index");
        }
    }
}
