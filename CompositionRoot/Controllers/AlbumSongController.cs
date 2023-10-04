using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumSongController : ControllerBase
    {
        private readonly IAlbumSongBL _albumSongBL;

        public AlbumSongController(IAlbumSongBL albumSongBL)
        {
            _albumSongBL = albumSongBL;
        }

        [HttpGet]
        public List<AlbumSong> Get()
        {
            return _albumSongBL.Read();
        }

        [HttpGet]
        [Route("GetById")]
        public AlbumSong Get(int albumSongId)
        {
            return _albumSongBL.Read(albumSongId);
        }

        [HttpPost]
        public void Post(AlbumSong albumSong)
        {
            _albumSongBL.Create(albumSong);
        }

        [HttpPut]
        public void Update(AlbumSong albumSong)
        {
            _albumSongBL.Update(albumSong);
        }

        [HttpDelete]
        public void Delete(int albumSongId)
        {
            _albumSongBL.Delete(albumSongId);
        }
    }
}
