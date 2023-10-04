using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicGenreController : ControllerBase
    {
        private readonly IMusicGenreBL _musicGenreBL;

        public MusicGenreController(IMusicGenreBL musicGenreBL)
        {
            _musicGenreBL = musicGenreBL;
        }

        [HttpGet]
        public List<MusicGenre> Get()
        {
            return _musicGenreBL.Read();
        }

        [HttpGet]
        [Route("GetById")]
        public MusicGenre Get(int musicGenreId)
        {
            return _musicGenreBL.Read(musicGenreId);
        }

        [HttpPost]
        public void Post(MusicGenre musicGenre)
        {
            _musicGenreBL.Create(musicGenre);
        }

        [HttpPut]
        public void Update(MusicGenre musicGenre)
        {
            _musicGenreBL.Update(musicGenre);
        }

        [HttpDelete]
        public void Delete(int musicGenreId)
        {
            _musicGenreBL.Delete(musicGenreId);
        }
    }
}
