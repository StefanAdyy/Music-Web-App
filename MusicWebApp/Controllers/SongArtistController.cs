using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class SongArtistController : Controller
    {
        ISongArtistBL _songArtistBL;
        ISongBL _songBL;
        IArtistBL _artistBL;

        public SongArtistController(ISongArtistBL songArtistBL, ISongBL songBL, IArtistBL artistBL)
        {
            _songArtistBL=songArtistBL;
            _songBL=songBL;
            _artistBL=artistBL;
        }

        public IActionResult Index()
        {
            return View(_songArtistBL.Read());
        }

        public IActionResult Create()
        {
            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title + ", release date: " + item.ReleaseDate.ToShortDateString() });
            ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.FirstName + " " + item.SecondName });
            return View();
        }

        [HttpPost]
        public IActionResult Create(SongArtist songArtist)
        {
            if (ModelState.IsValid)
            {
                _songArtistBL.Create(songArtist);
            }
            else
            {
                ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title + ", release date: " + item.ReleaseDate.ToShortDateString() });
                ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.FirstName + " " + item.SecondName });
                return View(songArtist);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int songArtistId)
        {
            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title + ", release date: " + item.ReleaseDate.ToShortDateString() });
            ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.FirstName + " " + item.SecondName });
            return View(_songArtistBL.Read(songArtistId));
        }

        [HttpPost]
        public IActionResult Edit(SongArtist songArtist)
        {
            if (ModelState.IsValid)
            {
                _songArtistBL.Update(songArtist);
            }
            else
            {
                ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title + ", release date: " + item.ReleaseDate.ToShortDateString() });
                ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.FirstName + " " + item.SecondName });
                return View(songArtist);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int songArtistId)
        {
            _songArtistBL.Delete(songArtistId);
            return RedirectToAction("Index");   
        }
    }
}
