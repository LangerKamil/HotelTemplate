using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApplication.Models;

namespace HotelApplication.Models
{
    public class Reservation
    {
        public byte Id { get; set; }
        public byte CustomerId { get; set; }
        public Customer Customer { get; set; }
        public byte RoomId { get; set; }
        public Room Room { get; set; }
        public ReservationStatus RStatus { get; set; }
        // public double Pricing { get; set; }
    }
}