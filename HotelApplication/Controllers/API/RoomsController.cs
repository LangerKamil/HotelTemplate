using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplication.Models;
using HotelApplication.DTOs;
using System.Data.Entity;
using AutoMapper;

namespace HotelApplication.Controllers.API
{
    public class RoomsController : ApiController
    {
        private ApplicationDbContext _context;

        public RoomsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/Services/Rooms
        [Route("api/Services/Rooms")]
        public IEnumerable<RoomDTO> GetRooms()
        {
            return _context.Rooms.Include(c=>c.RoomStatus).ToList().Select(Mapper.Map<Room,RoomDTO>);
        }


        // PUT /api/Services/Rooms/1

        [HttpPut]
        [Route("api/Services/Rooms/{id}")]
        public void UpdateRoom(RoomDTO roomDTO,int id)
        {
            var roomInDb = _context.Rooms.SingleOrDefault(r => r.Id == id);

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            if (roomInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(roomDTO, roomInDb);

            _context.SaveChanges();
        }


    }
}
