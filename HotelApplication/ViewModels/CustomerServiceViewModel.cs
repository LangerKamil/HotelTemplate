using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApplication.Models;

namespace HotelApplication.ViewModels
{
    public class CustomerServiceViewModel
    {
        public List<Room> Rooms { get; set; }
        public List<Customer> Customer { get; set; }
    }
}