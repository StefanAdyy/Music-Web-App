using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private readonly ISongBL _songBL;

        public SongController(ISongBL songBL)
        {
            _songBL = songBL;
        }

        [HttpGet]
        public List<Song> Get()
        {
            return _songBL.Read();
        }

        [HttpGet]
        [Route("GetById")]
        public Song Get(int songId)
        {
            return _songBL.Read(songId);
        }

        [HttpPost]
        public void Post(Song song)
        {
            _songBL.Create(song);
        }

        [HttpPut]
        public void Put(Song song)
        {
            _songBL.Update(song);
        }

        [HttpDelete]
        public void Delete(int songId)
        {
            _songBL.Delete(songId);
        }
    }
}
