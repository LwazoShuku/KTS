using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using KTS.Migrations.KtsStore;
using KTS.data;
using System.Net;
using System.Text.RegularExpressions;

namespace KTS.Models
{
    public class Booking
    {

       

        [Key]
        public string sessionUser {get;set;}

        [Key]
        [Display(Name ="Date for booking")]
        [Required(ErrorMessage ="Select the time for your booking")]
        public DateTime dateT { get; set; }

         [Key]
        [Display(Name ="Booking Time")]
        public string time { get; set; }

         public Services GetServices { get; set; }
        public string Serviceid { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Enter Your Name")]
        public string Name { get; set; }

        [Display(Name = "Customer Surname")]
        [Required(ErrorMessage = "Enter your surname")]
        public string Surname { get; set; }

        [Display(Name = "Vehicle Registration Number")]
        [Required(ErrorMessage = "Enter vehicle Registration")]
        public string vehicle_Registration { get; set; }



       
    }
}