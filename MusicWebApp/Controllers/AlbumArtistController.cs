using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class AlbumArtistController : Controller
    {
        private readonly IAlbumArtistBL _albumArtistBL;
        private readonly IArtistBL _artistBL;
        private readonly IAlbumBL _albumBL;

        public AlbumArtistController(IAlbumArtistBL albumArtistBL, IArtistBL artistBL, IAlbumBL albumBL)
        {
            _albumArtistBL = albumArtistBL;
            _artistBL = artistBL;
            _albumBL = albumBL;
        }

        public IActionResult Index()
        {
            return View(_albumArtistBL.Read());
        }

        public IActionResult ReadAlbumId()
        {
            return View();
        }

        public IActionResult GetArtistIdByAlbumId(int albumId)
        {
            return View(_albumArtistBL.ReadByAlbumId(albumId));
        }

        public IActionResult Create()
        {
            ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.FirstName + " " + item.SecondName });
            ViewBag.Albums = _albumBL.Read().Select(item => new SelectListItem { Value = item.AlbumId.ToString(), Text = item.Title + ", record label: " + item.RecordLabel + ", release date: " + item.ReleaseDate.ToShortDateString() });
            return View();
        }

        [HttpPost]
        public IActionResult Create(AlbumArtist albumArtist)
        {
            if (ModelState.IsValid)
            {
                _albumArtistBL.Create(albumArtist);
            }
            else
            {
                ViewBag.Artists = _artistBL.Read().Select(a => new SelectListItem { Value = a.ArtistId.ToString(), Text = a.FirstName + " " + a.SecondName });
                return View(albumArtist);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int albumArtistId)
        {
            ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.FirstName + " " + item.SecondName });
            ViewBag.Albums = _albumBL.Read().Select(item => new SelectListItem { Value = item.AlbumId.ToString(), Text = item.Title + ", record label: " + item.RecordLabel + ", release date: " + item.ReleaseDate.ToShortDateString() });
            return View(_albumArtistBL.Read(albumArtistId));
        }

        [HttpPost]
        public IActionResult Edit(AlbumArtist albumArtist)
        {
            if (ModelState.IsValid)
            {
                _albumArtistBL.Update(albumArtist);
            }
            else
            {
                return View(albumArtist);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int albumArtistId)
        {
            _albumArtistBL.Delete(albumArtistId);
            return RedirectToAction("Index");
        }
    }
}
