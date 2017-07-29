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
            var movieList = _context.Movies.Include(c => c.MovieGenre).ToList();

            return View(movieList);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.MovieGenre).SingleOrDefault(c => c.Id == id);
            return View(movie);
        }

    }
}