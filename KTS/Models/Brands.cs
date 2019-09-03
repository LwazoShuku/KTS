using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace KTS.Models
{
    public class Brands
    {

        [Key]
        [Required(ErrorMessage ="Enter ID")]
        [Display(Name ="Brand Code")]
       public string brandID { get; set; }

        [Display(Name = "Brand Name")]
        [Required(ErrorMessage = "Enter the brand of the type of product")]
       public string brandName { get; set; }



        public string productTy { get; set; }
        public ProductType type { get; set; }

        public List<Products> GetProducts { get; set; }



    }
}