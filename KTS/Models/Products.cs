using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace KTS.Models
{
    public class Products
    {

        [Key]
        [Required(ErrorMessage ="Enter Product Code")]
        [Display(Name ="Product Code")]
        public int ProductId { get; set; }


        [Required(ErrorMessage = "Enter the name of the product")]
        [Display(Name = "Product Code")]
        public string ProductName { get; set; }

   
        public List<Inventory> inventories { get; set; }
      



        public string brandID { get; set; }

        public Brands GetBrands { get; set; }


        public string suppId { get; set; }

        public Supplier supplier { get; set; }

        
       
    }
 

}