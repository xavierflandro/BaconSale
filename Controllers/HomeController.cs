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
        private MovieDBContext _context;
        private IMovieRepository _repository;

        public HomeController(ILogger<HomeController> logger, MovieDBContext context, IMovieRepository repository)
        {
            _logger = logger;
            _context = context;         //  Assign passed context to private context property
            _repository = repository;
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

        //  Pass context into MyMovies view and exclude objrect with title "Independence Day
        public IActionResult MyMovies()
        {
            return View(_context.Movies.Where(m => m.Title != "Independence Day"));
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
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return View("Confirmation", movie);
        }

        //  Pass in movie to prepopulate fields
        public IActionResult EditMovie(int movieId)
        {
            Movie movie = _context.Movies.Where(m => m.MovieId == movieId).FirstOrDefault();
            return View(movie);
        }

        [HttpPost]
        //  Pass new movie object as well as target movie id to make necessary changes on original object
        public IActionResult EditConfirmation(Movie movie, int movieId)
        {
            //Update database
            Movie targetMovie = _context.Movies.Where(m => m.MovieId == movieId).FirstOrDefault();
            targetMovie.Category = movie.Category;
            targetMovie.Title = movie.Title;
            targetMovie.Year = movie.Year;
            targetMovie.Director = movie.Director;
            targetMovie.Rating = movie.Rating;
            targetMovie.Edited = movie.Edited;
            targetMovie.LentTo = movie.LentTo;
            targetMovie.Notes = movie.Notes;

            _context.SaveChanges();
            return View(movie);
        }


        //  Upon deletion of movie, delete from database and direct to confirmation page
        public IActionResult DeleteMovie(int movieId)
        {
            //  Delete from database
            Movie targetMovie = _context.Movies.Where(m => m.MovieId == movieId).FirstOrDefault();
            _context.Remove(targetMovie);
            _context.SaveChanges();
            return View("DeleteConfirmation", targetMovie);
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
