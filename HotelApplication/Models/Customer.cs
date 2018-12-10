using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HotelApplication.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }

        public Gender Gender { get; set; }

        public byte GenderId { get; set; }

    }
}