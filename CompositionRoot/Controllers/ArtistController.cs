using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistBL _artistBL;

        public ArtistController(IArtistBL artistBL)
        {
            _artistBL = artistBL;
        }

        [HttpGet]
        public List<Artist> Get()
        {
            return _artistBL.Read();
        }

        [HttpGet]
        [Route("GetById")]
        public Artist Get(int artistId)
        {
            return _artistBL.Read(artistId);
        }

        [HttpPost]
        public void Post(Artist artist)
        {
            _artistBL.Create(artist);
        }

        [HttpPut]
        public void Update(Artist artist)
        {
            _artistBL.Update(artist);
        }

        [HttpDelete]
        public void Delete(int artistId)
        {
            _artistBL.Delete(artistId);
        }
    }
}
