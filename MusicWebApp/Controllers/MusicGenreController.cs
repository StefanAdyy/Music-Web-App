using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MusicWebApp.Controllers
{
    public class MusicGenreController : Controller
    {
        private readonly IMusicGenreBL _musicGenreBL;

        public MusicGenreController(IMusicGenreBL musicGenreBL)
        {
            _musicGenreBL=musicGenreBL;
        }
        public IActionResult Index()
        {
            return View(_musicGenreBL.Read());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MusicGenre musicGenre)
        {
            if (ModelState.IsValid)
            {
                _musicGenreBL.Create(musicGenre);
            }
            else
            {
                return View(musicGenre);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int musicGenreId)
        {
            return View(_musicGenreBL.Read(musicGenreId));
        }

        [HttpPost]
        public IActionResult Edit(MusicGenre musicGenre)
        {
            if (ModelState.IsValid)
            {
                _musicGenreBL.Update(musicGenre);
            }
            else
            {
                return View(musicGenre);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int musicGenreId)
        {
            _musicGenreBL.Delete(musicGenreId);
            return RedirectToAction("Index");
        }
    }
}
