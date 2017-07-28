using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer() {Name = "Hannah Barbera", Id = 1},
                new Customer() {Name = "Santa Claus", Id = 2},
                new Customer() {Name = "Cool Bananas", Id = 3},
                new Customer() {Name = "Crazy Eye Joe", Id = 4},
                new Customer() {Name = "St Nicholas", Id = 5}
            };

            var customerList = new CustomerViewModel()
            {
                Customers = customers
            };
               
            return View(customerList);
        }
    }
}