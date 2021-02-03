using BaconSale.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BaconSale.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //  Home Action
        public IActionResult Index()
        {
            return View();
        }
        //  Direct user to MyPodcasts view on get request
        public IActionResult MyPodcasts()
        {
            return View();
        }
        //  Pass temporary storage into MyMovies view and exclude objrect with title "Independence Day
        public IActionResult MyMovies()
        {
            return View(TempStorage.Movies.Where(m => m.Title != "Independence Day"));
        }
        //  Direct user to AddMovie view on get request
        [HttpGet]
        public IActionResult AddMovies()
        {
            return View();
        }
        //  Direct user to Confirmation view, passing form data on post request (form submission)
        [HttpPost]
        public IActionResult AddMovies(Movie movie)
        {
            TempStorage.AddMovie(movie);
            return View("Confirmation", movie);
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
