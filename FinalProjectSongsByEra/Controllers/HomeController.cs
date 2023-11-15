using FinalProjectSongsByEra.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}