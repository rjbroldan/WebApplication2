using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movies Movies { get; set; }
        public List<Customer> Customers { get; set; }

    }
}