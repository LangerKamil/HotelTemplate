using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApplication.Models;
using HotelApplication.ViewModels;


namespace HotelApplication.Controllers
{
    [Authorize]
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
            // Initializing room status
            //foreach (var a in  _context.Rooms)
            //{
            //    a.RoomStatusId = 1;
            //}

            // Updating room status
            var today = DateTime.Now;
            var reservationList = _context.Reservations.ToList();

            foreach (var a in reservationList.Where(r => r.CheckIn <= today && r.CheckOut > today))
            {
                var id = a.RoomId;

                var room = _context.Rooms.Where(r => r.Id == id).SingleOrDefault();
                room.RoomStatusId = 2;
                
            }

            _context.SaveChanges();

            var viewModel = new OverviewViewModel
            {
                Customers = _context.Customers.ToList(),
                Rooms = _context.Rooms.ToList(),
                Reservation = _context.Reservations.ToList()
            };

            return View(viewModel);
        }

        public ActionResult Rooms()
        {
            var rooms = _context.Rooms.ToList();

            return View(rooms);
        }

        public ActionResult Reservations()
        {
            var reservations = _context.Reservations.ToList();

            return View(reservations);
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