using BusinessLogic.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace MusicWebApp.Controllers
{
    public class ExitController : Controller
    {
        private readonly IEntryDateBL _entryDateBL;
        public ExitController(IEntryDateBL entryDateBL)
        {
            _entryDateBL=entryDateBL;
        }

        public IActionResult Exit()
        {
            _entryDateBL.UpdateMinutes();
            return View();
        }
    }
}
