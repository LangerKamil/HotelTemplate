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
            var rooms = _context.Rooms.ToList();

            return View(rooms);
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

    }
}