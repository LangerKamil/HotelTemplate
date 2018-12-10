using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApplication.Models;
using HotelApplication.ViewModels;

namespace HotelApplication.Controllers
{
    public class ServiceController : Controller
    {
        private ApplicationDbContext _context;

        public ServiceController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Service
        [Route("Service/Overview")]
        public ActionResult Overview()
        {
            return View();
        }

        public ActionResult Rooms()
        {
            return View();
        }

        public ActionResult Reservations()
        {
            return View();
        }

        public ActionResult Customers()
        {
            var customer = _context.Customers.ToList();
            var room = _context.Rooms.ToList();

            var viewModel = new CustomerServiceViewModel
            {
                Customer = customer,
                Rooms = room
            };

            return View(viewModel);
        }

        public ActionResult CustomerDetails(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var room = _context.Rooms.ToList();
            var gender = _context.Genders.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                Rooms = _context.Rooms.ToList(),
                Genders = _context.Genders.ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Edit(Customer customer)
        {

            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new CustomerFormViewModel
            //    {
            //        Customer = customer,
            //        Rooms = _context.Rooms.ToList(),
            //        Genders = _context.Genders.ToList()
            //    };
            //return View("CustomerDetails",viewModel);
            //}

            var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            customerInDb.FirstName = customer.FirstName;
            customerInDb.LastName = customer.LastName; 
            customerInDb.IDNumber= customer.IDNumber; 
            customerInDb.PhoneNumber= customer.PhoneNumber; 
            customerInDb.EmailAddress= customer.EmailAddress;
            customerInDb.DateOfBirth= customer.DateOfBirth;
            customerInDb.Gender= customer.Gender;

            _context.SaveChanges();

            return RedirectToAction("Customers","Service");
        }
        
    }
}