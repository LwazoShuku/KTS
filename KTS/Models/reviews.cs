using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KTS.Models
{
    public class reviews
    {
        [Key]
        public string user { get; set; }

        [Required (ErrorMessage = "Please Enter Your review")]
        public string review { get; set; }


        public DateTime Date { get; set; }





    }
}