using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApplication.Models
{
    public class Room
    {

        public Room()
        {
            CheckIn = DateTime.Now;
            CheckOut = DateTime.Now;
        }
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