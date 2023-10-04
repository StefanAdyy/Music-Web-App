using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistBL _artistBL;
        private readonly INationalityBL _nationalityBL;

        public ArtistController(IArtistBL artistBL, INationalityBL nationalityBL)
        {
            _artistBL = artistBL;
            _nationalityBL = nationalityBL; 
        }

        public IActionResult Index()
        {
            return View(_artistBL.Read());
        }

        public IActionResult Create()
        {
            ViewBag.Nationalities = _nationalityBL.Read().Select(item => new SelectListItem { Value = item.NationalityId.ToString(), Text = item.NationalityName });
            return View();
        }

        [HttpPost]
        public IActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                //aici se fac validari pe server
                _artistBL.Create(artist);
            }
            else
            {
                ViewBag.Nationalities = _nationalityBL.Read().Select(item => new SelectListItem { Value = item.NationalityId.ToString(), Text = item.NationalityName });
                return View(artist);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int artistId)
        {
            ViewBag.Nationalities = _nationalityBL.Read().Select(item => new SelectListItem { Value = item.NationalityId.ToString(), Text = item.NationalityName });
            return View(_artistBL.Read(artistId));
        }

        [HttpPost]
        public IActionResult Edit(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _artistBL.Update(artist);
            }
            else
            {
                return View(artist);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int artistId)
        {
            _artistBL.Delete(artistId);
            return RedirectToAction("Index");
        }
    }
}
