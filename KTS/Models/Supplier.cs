using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace KTS.Models
{
    public class Supplier
    {

        [Key]
        [Required(ErrorMessage ="Enter the supplier code")]
        [Display(Name ="Supplier code")]
        public string suppId { get; set; }

        [Required(ErrorMessage ="Enter The name of supplier")]
        [Display(Name ="Supplier Name")]
        public string name { get; set; }

        [Required(ErrorMessage ="Enter Email address")]
        [Display(Name ="Address")]
        public string address { get; set; }

        [Required(ErrorMessage ="Enter Contact number")]
        [Display(Name ="Contact")]
        public int contact { get; set; }

        [Required(ErrorMessage ="Enter Telephone Number")]
        [Display(Name ="landline Telephone")]
        public int tel { get; set; }


        [Display(Name ="Email address")]
        [EmailAddress(ErrorMessage ="Enter Email address")]
        public string email { get; set; }


       public List<Products> GetProducts { get; set; }
      
    }
}