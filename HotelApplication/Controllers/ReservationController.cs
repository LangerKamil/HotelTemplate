using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApplication.Models;
using HotelApplication.ViewModels;
using System.Data.Entity;
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

        public ActionResult Create(Customer customer,Room room)
        {

            var roomInDb = _context.Rooms.First(r => r.RoomTypeId == room.RoomTypeId && r.RoomStatusId == 1);

            roomInDb.CheckIn = room.CheckIn;
            roomInDb.CheckOut = room.CheckOut;
            roomInDb.RoomStatusId = 2;

            _context.Customers.Add(customer);
            _context.SaveChanges();

            var reservation = new Reservation
            {
                Customer = _context.Customers.FirstOrDefault(c => c.IDNumber == customer.IDNumber),
                Room = roomInDb,
                RStatusId = 3
            };

            _context.Reservations.Add(reservation);

            _context.SaveChanges();

            return RedirectToAction("Reservations", "Service");
        }

    }
}