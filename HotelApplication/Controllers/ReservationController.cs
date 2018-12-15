using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApplication.Models;
using HotelApplication.ViewModels;
using System.Data.Entity;
using HotelApplication.Classes;


namespace HotelApplication.Controllers
{
    public class ReservationController : Controller
    {
        private ApplicationDbContext _context;
        private DateChecker _datechecker;

        public ReservationController()
        {
            _datechecker = new DateChecker();
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult NewForm()
        {
            var reservation = new Reservation
            {
                Customer = new Customer(),
                Room = new Room(),
                Genders = _context.Genders.ToList(),
                RoomTypes = _context.RoomTypes.ToList(),
            };

            return View(reservation);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Create(Customer customer, Room room, Reservation reserv)
        {


            if (_datechecker.CheckDateAvailability(room, reserv, _context)==null)

                return RedirectToAction("Reservations","Service");

            var roomInDb = _datechecker.CheckDateAvailability(room, reserv, _context);

            roomInDb.RoomStatusId = 2;

            _context.Customers.Add(customer);
            _context.SaveChanges();

            var reservation = new Reservation
            {
                Customer = _context.Customers.First(c => c.IDNumber == customer.IDNumber),
                Room = roomInDb,
                RStatusId = 3,
                CheckIn = reserv.CheckIn,
                CheckOut = reserv.CheckOut,
                RoomStatusId= 2
            };

            _context.Reservations.Add(reservation);

            _context.SaveChanges();

            return RedirectToAction("Reservations", "Service");
        }

    }
}