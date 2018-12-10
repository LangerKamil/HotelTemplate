using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApplication.Models
{
    public class Room
    {
        public byte Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public byte RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public byte RoomStatusId { get; set; }
        public RoomStatus RoomStatus { get; set; }
    }
}