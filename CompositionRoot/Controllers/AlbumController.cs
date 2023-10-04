using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumBL _albumBL;

        public AlbumController(IAlbumBL albumBL)
        {
            _albumBL = albumBL;
        }

        [HttpGet]
        public List<Album> Get()
        {
            return _albumBL.Read();
        }

        [HttpGet]
        [Route("GetById")]
        public Album Get(int albumId)
        {
            return _albumBL.Read(albumId);
        }

        [HttpPost]
        public void Post(Album album)
        {
            _albumBL.Create(album);
        }

        [HttpPut]
        public void Update(Album album)
        {
            _albumBL.Update(album);
        }

        [HttpDelete]
        public void Delete(int albumId)
        {
            _albumBL.Delete(albumId);
        }
    }
}
