using FinalProjectSongsByEra.Models;
using Microsoft.AspNetCore.Mvc;
// This controller handles requests related to songs from the MySql database.
// Key Points:
// - Actions for listing, viewing, creating, updating, and deleting songs.(C.R.U.D.)
// - Uses Repository for data access.
namespace FinalProjectSongsByEra.Controllers
{
    public class SongsFrom1950Controller : Controller
    {
        private readonly ISongRepository _repo;

        public SongsFrom1950Controller(ISongRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var songs = _repo.GetAllSongs();
            return View(songs);
        }
        public IActionResult ViewSong(int id)
        {
            var song = _repo.GetSong(id);
            return View(song);
        }
        public IActionResult UpdateSong(int id)
        {
            SongsFrom1950 song = _repo.GetSong(id);
            if (song == null)
            {
                return View("Song Not Found");
            }
            return View(song);
        }
        public IActionResult UpdateSongToDatabase(SongsFrom1950 song)
        {
            _repo.UpdateSong(song);

            return RedirectToAction("Index", new { id = song.ID });
        }
        public IActionResult CreateSong()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSongToDatabase(SongsFrom1950 song)
        {
            _repo.AddSong(song);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSong(int id)
        {
            var song = _repo.GetSong(id);
            if (song == null)
            {
                return View("Song Not Found");
            }
            return View(song);
        }

        [HttpPost]
        public IActionResult DeleteSongFromDatabase(int id)
        {
            _repo.DeleteSong(id);
            return RedirectToAction("Index");
        }
    }
}
