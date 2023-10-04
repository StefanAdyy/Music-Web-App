using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumArtistController : ControllerBase
    {
        private readonly IAlbumArtistBL _albumArtistBL;

        public AlbumArtistController(IAlbumArtistBL albumArtistBL)
        {
            _albumArtistBL=albumArtistBL;
        }

        [HttpGet]
        public List<AlbumArtist> Get()
        {
            return _albumArtistBL.Read();
        }

        [HttpGet]
        [Route("GetById")]
        public AlbumArtist Get(int albumArtistId)
        {
            return _albumArtistBL.Read(albumArtistId);
        }

        [HttpPost]
        public void Post(AlbumArtist albumArtist)
        {
            _albumArtistBL.Create(albumArtist);
        }

        [HttpPut]
        public void Update(AlbumArtist albumArtist)
        {
            _albumArtistBL.Update(albumArtist);
        }

        [HttpDelete]
        public void Delete(int albumArtistId)
        {
            _albumArtistBL.Delete(albumArtistId);
        }
    }
}
