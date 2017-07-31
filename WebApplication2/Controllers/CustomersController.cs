using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;
using System.Data.Entity.Validation;

namespace WebApplication2.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //sort may slow down the performance
            var customers = _context.Customers.Include(c => c.MembershipType).OrderBy(o => o.Name).ToList();
                          
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().FirstOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult NewCustomer()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            DateTime date;
            if (customer.Id == 0)
            {
                if (customer.BirthDate.HasValue)
                {
                    date = (DateTime)customer.BirthDate;
                    if (date.Year < 1900)
                        customer.BirthDate = new DateTime(1900, 01, 01);
                }                    
                _context.Customers.Add(customer);
            }      
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;                
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewletters = customer.IsSubscribedToNewletters;

                if (customer.BirthDate.HasValue)
                {
                    date = (DateTime)customer.BirthDate;
                    if (date.Year > 1900)
                        customerInDb.BirthDate = customer.BirthDate;
                    else
                    {
                        customerInDb.BirthDate = new DateTime(1900, 01, 01);
                    }   
                }
                else
                {
                    customerInDb.BirthDate = customer.BirthDate;
                }



            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult EditCustomer(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
                        
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

    }
}