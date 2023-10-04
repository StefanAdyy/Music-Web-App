using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistBL _playlistBL;
        private readonly IPlaylistSongBL _playlistSongBL;
        private readonly IPlaylistArtistBL _playlistArtist;
        private readonly IPlaylistAlbumBL _playlistAlbumBL;
        private readonly ISongBL _songBL;
        private readonly IArtistBL _artistBL;
        private readonly IAlbumBL _albumBL;
        public PlaylistController(IPlaylistBL playlistBL, IPlaylistSongBL playlistSongBL, ISongBL songBL, IArtistBL artistBL, IPlaylistArtistBL playlistArtistBL, IAlbumBL albumBL, IPlaylistAlbumBL playlistAlbumBL)
        {
            _playlistBL = playlistBL;
            _playlistSongBL = playlistSongBL;
            _songBL = songBL;
            _artistBL = artistBL;
            _playlistArtist = playlistArtistBL;
            _albumBL = albumBL;
            _playlistAlbumBL = playlistAlbumBL;
            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title });
        }
        public ActionResult Index()
        {
            return View(_playlistBL.Read());
        }

        public ActionResult Details(int playlistId)
        {
            ViewBag.PlaylistId = playlistId;
            return View(_playlistSongBL.ReadByPlaylistId(playlistId));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _playlistBL.Create(playlist);
            }
            else
            {
                return View(playlist);
            }

            return RedirectToAction("Details", new { playlistId = _playlistBL.GetLastAddedPlaylist().PlaylistId });
        }

        public IActionResult Edit(int playlistId)
        {
            Playlist playlist = _playlistBL.Read(playlistId);
            return View(playlist);
        }

        [HttpPost]
        public IActionResult Edit(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _playlistBL.Update(playlist);
            }
            else
            {
                return View(playlist);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int playlistId)
        {
            _playlistBL.Delete(playlistId);
            return RedirectToAction("Index");
        }

        public IActionResult Like(int songId, int playlistId)
        {
            _songBL.AddLike(songId);
            return RedirectToAction("Details", new { playlistId = playlistId });
        }

        public IActionResult AddSong(int playlistId)
        {
            PlaylistSong playlistSong = new PlaylistSong();
            playlistSong.PlaylistId = playlistId;
            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title });
            return View(playlistSong);
        }

        [HttpPost]
        public IActionResult AddSong(PlaylistSong playlistSong)
        {
            if (ModelState.IsValid)
            {
                _playlistSongBL.Create(playlistSong);
            }
            else
            {
                ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title });
                return View(playlistSong);
            }

            return RedirectToAction("Details", new { playlistId = playlistSong.PlaylistId });
        }

        public IActionResult AddArtist(int playlistId)
        {
            PlaylistArtist playlistArtist = new PlaylistArtist();
            playlistArtist.PlaylistId = playlistId;
            ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.FirstName + " " + item.SecondName });

            return View(playlistArtist);
        }

        [HttpPost]
        public IActionResult AddArtist(PlaylistArtist playlistArtist)
        {
            if (ModelState.IsValid)
            {
                _playlistArtist.Create(playlistArtist);
                _playlistSongBL.AddSongsFromArtist(playlistArtist.PlaylistId, playlistArtist.ArtistId);
            }
            else
            {
                ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.FirstName + " " + item.SecondName });
                return View(playlistArtist);
            }

            return RedirectToAction("Details", new { playlistId = playlistArtist.PlaylistId });
        }

        public IActionResult AddAlbum(int playlistId)
        {
            PlaylistAlbum playlistAlbum = new PlaylistAlbum();
            playlistAlbum.PlaylistId = playlistId;
            ViewBag.Albums = _albumBL.Read().Select(item => new SelectListItem { Value = item.AlbumId.ToString(), Text = item.Title });

            return View(playlistAlbum);
        }

        [HttpPost]
        public IActionResult AddAlbum(PlaylistAlbum playlistAlbum)
        {
            if (ModelState.IsValid)
            {
                _playlistAlbumBL.Create(playlistAlbum);
                _playlistSongBL.AddSongsFromAlbum(playlistAlbum.PlaylistId, playlistAlbum.AlbumId);
            }
            else
            {
                ViewBag.Albums = _albumBL.Read().Select(item => new SelectListItem { Value = item.AlbumId.ToString(), Text = item.Title });
                return View(playlistAlbum);
            }

            return RedirectToAction("Details", new { playlistId = playlistAlbum.PlaylistId });
        }

        public IActionResult DeleteSongFromPlaylist(int playlistSongId, int playlistId)
        {
            _playlistSongBL.Delete(playlistSongId);
            return RedirectToAction("Details", new { playlistId = playlistId });
        }
    }
}
