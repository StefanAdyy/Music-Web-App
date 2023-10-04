using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongArtistController : ControllerBase
    {
        private readonly ISongArtistBL _songArtistBL;

        public SongArtistController(ISongArtistBL songArtistBL)
        {
            _songArtistBL = songArtistBL;
        }

        [HttpGet]
        public List<SongArtist> Get()
        {
            return _songArtistBL.Read();
        }

        [HttpGet]
        [Route("GetById")]
        public SongArtist Get(int songArtistId)
        {
            return _songArtistBL.Read(songArtistId);
        }

        [HttpPost]
        public void Post(SongArtist songArtist)
        {
            _songArtistBL.Create(songArtist);
        }

        [HttpPut]
        public void Update(SongArtist songArtist)
        {
            _songArtistBL.Update(songArtist);
        }

        [HttpDelete]
        public void Delete(int songArtistId)
        {
            _songArtistBL.Delete(songArtistId);
        }
    }
}
