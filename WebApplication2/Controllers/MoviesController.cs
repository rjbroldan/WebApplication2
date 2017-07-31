using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;


namespace WebApplication2.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]


        public ActionResult Index()
        {
            //the sort may be very slow so remove that and put on server side if too slow
            var movieList = _context.Movies.Include(c => c.MovieGenre).OrderBy(o => o.Name).ToList();
 
            return View(movieList);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.MovieGenre).SingleOrDefault(c => c.Id == id);
            return View(movie);
        }

        public ActionResult NewMovie()
        {
            var movieGenres = _context.MovieGenres.ToList();
            var viewModel = new MovieFormViewModel
            {
                MovieGenres = movieGenres
            };
           
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create( Movies movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;

                if (movie.ReleaseDate.Year < 1900)
                    movie.ReleaseDate = new DateTime(1900, 01, 01);

                _context.Movies.Add(movie);
            }                
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.MovieGenreId = movie.MovieGenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

                if (movie.ReleaseDate.Year < 1900)              
                    movieInDb.ReleaseDate = new DateTime(1900, 01, 01);                                   
                else
                {
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                }                
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult EditMovie(int id)
        {
            var movie = _context.Movies.Include(c => c.MovieGenre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                MovieGenres = _context.MovieGenres.ToList()
            };
            return View("MovieForm", viewModel);
        }

    }
}