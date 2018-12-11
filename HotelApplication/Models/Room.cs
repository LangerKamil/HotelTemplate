using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HotelApplication.Models
{
    public class Room
    {
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Arrival Date")]
        public DateTime CheckIn { get; set; }

        [Required]
        [Display(Name = "Departure Date")]
        public DateTime CheckOut { get; set; }

        public byte RoomTypeId { get; set; }

        [Display(Name ="Room Size")]
        public RoomType RoomType { get; set; }
        public byte RoomStatusId { get; set; }
        public RoomStatus RoomStatus { get; set; }
    }
}