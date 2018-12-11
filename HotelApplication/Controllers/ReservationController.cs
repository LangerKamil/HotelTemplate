using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApplication.Models;
using HotelApplication.ViewModels;

namespace HotelApplication.Controllers
{
    public class ReservationController : Controller
    {
        private ApplicationDbContext _context;

        public ReservationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult NewForm()
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                Rooms = _context.Rooms.ToList(),
                Genders = _context.Genders.ToList(),
                RoomTypes = _context.RoomTypes.ToList(),
                Room = new Room()
            };

            return View(viewModel);
        }

        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);

            return RedirectToAction("Reservations", "Service");
        }
    }
}