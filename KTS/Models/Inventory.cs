using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace KTS.Models
{
    public class Inventory
    {
        [Key]
        public int inventoryid { get; set; }

        [Display(Name ="Model Name")]
        [Required(ErrorMessage ="Enter Model name")]
        public string ProductModelName { get; set; }

        [Display(Name ="Upload image")]
        public byte[] productImage { get; set; }

        [Required(ErrorMessage = "enter the price e.g   R123.55")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Enter product details e.g specs")]
        [Display(Name = "Product Description ")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Enter the amount of the product in stock")]
        [Display(Name = "Qty")]
        public int StockAmt { get; set; }

        public int ProductId { get; set; }

        public Products GetProducts { get; set; }


      

    }
}