using FinalProjectSongsByEra.Models;
using Microsoft.AspNetCore.Mvc;

// This controller handles requests related to the home page and error handling.
// Key Points:
// - Actions for rendering the home page and privacy policy(I do not utilize the privacy
// policy in this application.  It is good practice to keep the code in case you have a
// a use for it later.
// - Error handling action for displaying error details.


namespace FinalProjectSongsByEra.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISongRepository _repo;

        public HomeController(ISongRepository repo)
        {
            _repo = repo;
        }

        //public IActionResult Index()
        //{
        //    // Get a list of table names you want to display links for
        //    var tableNames = new List<string> { "songs_1950s", "songs_1960s", "songs_1970s", "songs_1980s", "songs_1990s", "songs_2000s", "songs_2010s"};

        //    // Pass the list of table names to the view
        //    return View(tableNames);
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
          
            var tableNames = new List<string> { "songs_1950s", "songs_1960s", "songs_1970s", "songs_1980s", "songs_1990s", "songs_2000s", "songs_2010s" };

            return View(tableNames);
        }

    }
}