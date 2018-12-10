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
            var customer = new Customer();
            var rooms = _context.Rooms.ToList();
            var gender = _context.Genders.ToList();
            var room = new Room();
            //var room = _context.
            
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                Rooms = rooms,
                Genders = gender,
                Room = room
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