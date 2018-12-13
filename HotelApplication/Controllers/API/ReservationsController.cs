using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplication.Models;
using System.Data.Entity;
using HotelApplication.DTOs;
using AutoMapper;

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
        public IEnumerable<ReservationDTO> GetReservations()
        {
            return _context.Reservations
                .Include(r=>r.Customer)
                .Include(r=>r.RStatus)
                .ToList()
                .Select(Mapper.Map<Reservation,ReservationDTO>);

        }

        // GET /api/Services/Reservations/1
        [Route("api/Services/Reservations/{id}")]
        public ReservationDTO GetReservation(int id)
        {
            var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);

            if(reservation == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Reservation,ReservationDTO>(reservation);
        }

        // PUT /api/Services/Reservations/1
        [HttpPut]
        [Route("api/Services/Reservations/{id}")]
        public void UpdateReservation(ReservationDTO reservationDTO,int id)
        {
            var reservationInDb = _context.Reservations.SingleOrDefault(r => r.Id == id);

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            if (reservationInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(reservationInDb, reservationDTO);

            _context.SaveChanges();
        }

        // DELETE /api/Services/Reservations/1
        [Route("api/Services/Reservations/{id}")]
        public void DeleteReservation(int id)
        {
            var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);

            if (reservation == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }


        // PUT /api/Services/Reservations/Status/1
        [HttpPut]
        [Route("api/Services/Reservations/Cancel/{id},{status}")]
        public void ReservationStatus(int id,string status)
        {
            var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);

            if (reservation == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            if (status == "confirm")
                reservation.RStatusId = 1;
                        
            else
                reservation.RStatusId = 2;

            _context.SaveChanges();
        }
    }
}
