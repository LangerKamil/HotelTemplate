using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApplication.Models;

namespace HotelApplication.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<Gender> Genders { get; set; }
        public List<Room> Rooms { get; set; }
        public Customer Customer { get; set; }
        public List<RoomType> RoomTypes { get; set; }
    }
}