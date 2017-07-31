using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<MovieGenres> MovieGenres { get; set; }
        public Movies Movie { get; set; }

    }
}