using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HotelApplication.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Gender> Genders { get; set; }

        public byte RoomId { get; set; }
        public Room Room { get; set; }

        public byte RoomStatusId { get; set; }
        public RoomStatus RoomStatus { get; set; }

        public List<RoomType> RoomTypes { get; set; }

        public byte RStatusId { get; set; }
        public ReservationStatus RStatus { get; set; }

        [Required]
        [Display(Name = "Departure Date")]
        public DateTime CheckIn { get; set; }

        [Required]
        [Display(Name = "Departure Date")]
        public DateTime CheckOut { get; set; }
        // public double Pricing { get; set; }
    }
}