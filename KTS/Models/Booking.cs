using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace KTS.Models
{
    public class Booking
    {

        [Key]
        public int bookingID { get; set; }


        
        public string sessionUser {get;set;}



        [Display(Name = "Booking Date")]
        [Required(ErrorMessage = "Please select a Date")]
        public string dateTime { get; set; }


        [Display(Name = " Booking Time")]
        [Required(ErrorMessage = "Select Time Of booking")]
        public int time { get; set; }


        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Enter Your Name")]
        public string Name { get; set; }

        [Display(Name = "Customer Surname")]
        [Required(ErrorMessage = "Enter your surname")]
        public string Surname { get; set; }

        [Display(Name = "Enter the vehicle you are making a booking for")]
        [Required(ErrorMessage = "Enter vehicle Registration")]
        public string vehicle_Registration { get; set; }


    }
}