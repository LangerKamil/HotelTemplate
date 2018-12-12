using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplication.Models;
using System.Data.Entity;

namespace HotelApplication.Controllers.API
{
    public class ReservationsController : ApiController
    {
        private ApplicationDbContext _context;

        public ReservationsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/Services/Reservations
        [Route("api/Services/Reservations")]
        public IEnumerable<Reservation> GetReservations()
        {
            var reservations = _context.Reservations.Include(r=>r.Customer).Include(r=>r.RStatus).ToList();

            return reservations; 
        }

        // GET /api/Services/Reservations/1
        [Route("api/Services/Reservations/{id}")]
        public Reservation GetReservation(int id)
        {
            var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);

            return reservation;
        }

        // PUT /api/Services/Reservations/1
        [HttpPut]
        [Route("api/Services/Reservations/{id}")]
        public void UpdateReservation(Reservation reservation,int id)
        {
            var reservationInDb = _context.Reservations.SingleOrDefault(r => r.Id == id);
            reservationInDb.RoomId = reservation.RoomId;
            reservationInDb.CustomerId = reservation.CustomerId;
            reservationInDb.RStatusId = reservation.RStatusId;

            _context.SaveChanges();
        }

        // DELETE /api/Services/Reservations/1
        [Route("api/Services/Reservations/{id}")]
        public void DeleteReservation(int id)
        {
            var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }

        // PUT /api/Services/Reservations/Status/1
        [HttpPut]
        [Route("api/Services/Reservations/Confirm/{id}")]
        public void ConfirmReservation(int id)
        {
            var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);

            reservation.RStatusId = 1;
            _context.SaveChanges();
        }

        // PUT /api/Services/Reservations/Status/1
        [HttpPut]
        [Route("api/Services/Reservations/Cancel/{id}")]
        public void CancelReservation(int id)
        {
            var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);

            reservation.RStatusId = 2;
            _context.SaveChanges();
        }
    }
}
