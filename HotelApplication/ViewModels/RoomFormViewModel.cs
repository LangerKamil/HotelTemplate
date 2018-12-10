using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApplication.Models;

namespace HotelApplication.ViewModels
{
    public class RoomFormViewModel
    {
        public Room Room { get; set; }
        public List<RoomType> RoomTypes { get; set; }
        public List<RoomStatus> RoomStatuses { get; set; }
    }
}