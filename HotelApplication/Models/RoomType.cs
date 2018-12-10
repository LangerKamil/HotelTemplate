using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApplication.Models
{
    public class RoomType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public byte TotalAmount { get; set; }
        public byte AvailableAmount { get; set; }
    }
}