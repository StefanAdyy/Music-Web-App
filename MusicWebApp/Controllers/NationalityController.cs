using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MusicWebApp.Controllers
{
    public class NationalityController : Controller
    {
        private readonly INationalityBL _nationalityBL;

        public NationalityController(INationalityBL nationalityBL)
        {
            _nationalityBL=nationalityBL;
        }

        public IActionResult Index()
        {
            return View(_nationalityBL.Read());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                _nationalityBL.Create(nationality);
            }
            else
            {
                return View(nationality);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int nationalityId)
        {
            return View(_nationalityBL.Read(nationalityId));
        }

        [HttpPost]
        public IActionResult Edit(Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                _nationalityBL.Update(nationality);
            }
            else
            {
                return View(nationality);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int nationalityId)
        {
            _nationalityBL.Delete(nationalityId);
            return RedirectToAction("Index");
        }
    }
}
