using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace KTS.Models
{
    public class ProductType
    {
      
        [Key]
        [Required(ErrorMessage = "Enter the Product type")]
        [Display(Name = "Product Type e.g Tyre")]
        public string productTy { get; set; }

      
        
        public List<Brands> brands { get; set; }

          
        


    }
}