using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApplication.Models;

namespace HotelApplication.ViewModels
{
    public class OverviewViewModel
    {
        public List<Customer> Customers{ get; set; }
        public List<Room> Rooms { get; set; }
        public List<Reservation> Reservation { get; set; }
    }
}