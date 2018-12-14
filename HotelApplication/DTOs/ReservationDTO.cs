using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApplication.Models;

namespace HotelApplication.DTOs
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Gender> Genders { get; set; }
        public byte RoomId { get; set; }
        public Room Room { get; set; }
        public List<RoomType> RoomTypes { get; set; }
        public byte RStatusId { get; set; }
        public ReservationStatus RStatus { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}