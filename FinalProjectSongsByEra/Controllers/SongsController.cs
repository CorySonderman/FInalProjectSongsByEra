using Microsoft.AspNetCore.Mvc;
using FinalProjectSongsByEra.Models;
// This controller handles requests related to songs from the MySql database.
// Key Points:
// - Actions for listing, viewing, creating, updating, and deleting songs.(C.R.U.D.)
// - Uses Repository for data access.
namespace FinalProjectSongsByEra.Controllers
{
    public class SongsController : Controller
    {
        private readonly ISongRepository _repo;

        public SongsController(ISongRepository repo)
        {
            _repo = repo;
        }

        // The action method for displaying songs from a specific table
        public IActionResult Index(string tableName)
        {
            var songs = _repo.GetAllSongs(tableName);
            return View(songs);
        }
        //public IActionResult Index(int decade)
        //{
        //    string tableName = $"songs_{decade}s";
        //    var songs = _repo.GetAllSongs(tableName);
        //    return View(songs);
        //}

        // Action methods to view individual song

        //public IActionResult ViewSong(int id, int decade)
        //{
        //    string tableName = $"songs_{decade}s";
        //    var song = _repo.GetSong(tableName, id);
        //    return View(song);
        //}

        //public IActionResult ViewSong(int id, int decade)
        //{
        //    string tableName = $"songs_{decade}s";
        //    var song = _repo.GetSong(tableName, id);
        //    return View(song);
        //}
        //public IActionResult ViewSong(int id, string tableName)
        //{
        //    var song = _repo.GetSong(tableName, id);
        //    return View(song);
        //}
        public IActionResult ViewSong(int id, string decade, string tableName)
        {
            Console.WriteLine($"Table Name: {tableName}"); // Add this line for logging
            var song = _repo.GetAllSongs(tableName).FirstOrDefault(s => s.ID == id);
            return View(song);
        }
        //public IActionResult UpdateSong(int id, int decade)
        //{
        //    string tableName = $"songs_{decade}s";
        //    var song = _repo.GetSong(tableName, id);
        //    if (song == null)
        //    {
        //        return View("Song Not Found");
        //    }
        //    return View(song);
        //}
        public IActionResult UpdateSong(int id, int decade)
        {
            string tableName = $"songs_{decade}s";
            var song = _repo.GetAllSongs(tableName).FirstOrDefault(s => s.ID == id);
            if (song == null)
            {
                return View("Song Not Found");
            }
            return View(song);
        }


        //[HttpPost]
        //public IActionResult UpdateSongToDatabase(ISong song, int decade)
        //{
        //    string tableName = $"songs_{decade}s";
        //    _repo.UpdateSong(tableName, song);

        //    return RedirectToAction("Index", new { decade });
        //}
        [HttpPost]
        public IActionResult UpdateSongToDatabase(ISong song, int decade)
        {
            string tableName = $"songs_{decade}s";
            _repo.UpdateSong(tableName, song);

            return RedirectToAction("Index", new { tableName });
        }

        //[HttpPost]
        //public IActionResult UpdateSongToDatabase(ISong song, int decade)
        //{
        //    string tableName = $"songs_{decade}s";

        //    // Ensure that the song ID is valid
        //    if (song.ID <= 0)
        //    {
        //        return View("Song Not Found");
        //    }

        //    // Check if the song with the given ID exists in the database
        //    var existingSong = _repo.GetSong(tableName, song.ID);
        //    if (existingSong == null)
        //    {
        //        return View("Song Not Found");
        //    }

        //    // Update the existing song with the new values
        //    existingSong.Title = song.Title;
        //    existingSong.Artist = song.Artist;
        //    existingSong.Genre = song.Genre;
        //    existingSong.YearReleased = song.YearReleased;

        //    // Call the repository method to update the song in the database
        //    _repo.UpdateSong(tableName, existingSong);

        //    // Redirect to the song list page for the specified decade
        //    return RedirectToAction("Index", new { tableName });
        //}

        public IActionResult CreateSong(int decade)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSongToDatabase(ISong song, int decade)
        {
            string tableName = $"songs_{decade}s";
            _repo.AddSong(tableName, song);
            return RedirectToAction("Index", new { decade });
        }

        public IActionResult DeleteSong(int id, int decade)
        {
            string tableName = $"songs_{decade}s";
            var song = _repo.GetAllSongs(tableName).FirstOrDefault(s => s.ID == id);
            if (song == null)
            {
                return View("Song Not Found");
            }
            return View(song);
        }

        [HttpPost]
        public IActionResult DeleteSongFromDatabase(int id, int decade)
        {
            string tableName = $"songs_{decade}s";
            _repo.DeleteSong(tableName, id);
            return RedirectToAction("Index", new { decade });
        }
    }
}
