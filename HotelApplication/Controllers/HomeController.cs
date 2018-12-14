using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApplication.Models;
using HotelApplication.ViewModels;

namespace HotelApplication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    Rooms = _context.Rooms.ToList(),
                    Genders = _context.Genders.ToList(),
                    RoomTypes = _context.RoomTypes.ToList()
                };

                return View("Booking", viewModel);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {

                return View();
        }

        public ActionResult Booking()
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                Rooms = _context.Rooms.ToList(),
                Genders = _context.Genders.ToList(),
                Room = new Room(),
                RoomTypes = _context.RoomTypes.ToList()
            };

            return View(viewModel);
        }

        public ActionResult Gallery()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}