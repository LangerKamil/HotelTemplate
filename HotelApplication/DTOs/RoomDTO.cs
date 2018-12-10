using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApplication.Models;

namespace HotelApplication.DTOs
{
    public class RoomDTO
    {
        public byte Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public byte RoomTypeId { get; set; }
        public RoomTypeDTO RoomType { get; set; }
        public byte RoomStatusId { get; set; }
        public RoomStatusDTO RoomStatus { get; set; }
    }
}