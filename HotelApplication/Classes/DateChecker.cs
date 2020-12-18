using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApplication.Models;

namespace HotelApplication.Classes
{
    public class DateChecker 
    {
        public Room CheckDateAvailability(Room _room, Reservation _new, ApplicationDbContext _context)
        {

            var tempReservList = new List<Reservation>();

            foreach (var a in _context.Reservations.Where(
                r => r.Room.RoomTypeId == _room.RoomTypeId &&
                r.RoomStatusId != 1 &&
                r.CheckIn <= _new.CheckIn && r.CheckOut >= _new.CheckOut ||
                r.CheckIn <= _new.CheckIn && r.CheckOut > _new.CheckIn ||
                r.CheckIn < _new.CheckOut && r.CheckOut >= _new.CheckOut))
               
            {
                tempReservList.Add(a);
            }

            var roomType = _context.RoomTypes.First(t => t.Id == _room.RoomTypeId);

            var tempRoomList = tempReservList.Select(r => r.Room).ToList();

            if (tempReservList.Count() >= roomType.TotalAmount)
                return null;

            else
                return _context.Rooms.Where(rm => rm.RoomTypeId == _room.RoomTypeId &&
                tempRoomList.Select(res => res.Id != rm.Id).FirstOrDefault()).FirstOrDefault();

        }

    }

}