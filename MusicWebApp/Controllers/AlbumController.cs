using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MusicWebApp.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumBL _albumBL;
        public AlbumController(IAlbumBL albumBL)
        {
            _albumBL = albumBL;
        }

        public IActionResult Index()
        {
            return View(_albumBL.Read());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                _albumBL.Create(album);
            }
            else
            {
                return View(album);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int albumId)
        {
            return View(_albumBL.Read(albumId));
        }

        [HttpPost]
        public IActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                _albumBL.Update(album);
            }
            else
            {
                return View(album);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int albumId)
        {
            _albumBL.Delete(albumId);
            return RedirectToAction("Index");
        }
    }
}
