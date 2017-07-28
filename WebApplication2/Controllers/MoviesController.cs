using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;


namespace WebApplication2.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movies() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer() {Name = "Customer 1"},
                new Customer() {Name = "Customer 2"},
                new Customer() {Name = "Customer 3"},
                new Customer() {Name = "Customer 4"},
                new Customer() {Name = "Customer 5"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movies = movie,
                Customers = customers
            };

            return View(viewModel);            
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

          
    }
}