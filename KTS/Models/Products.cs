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
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Enter product details e.g specs")]
        [Display(Name = "Product Description ")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "enter the price e.g   R123.55")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Enter the amount of the product in stock")]
        [Display(Name = "Qty")]
        public int StockAmt { get; set; }

        [Required(ErrorMessage = "Enter the type of item this is e.g Service/Product")]
        [Display(Name = "Item Type")]
        public string ItemType { get; set; } // We could set this to a default value of Product

        public string brandID { get; set; }

        public Brands GetBrands { get; set; }


        public string suppId { get; set; }

        public Supplier supplier { get; set; }

        public List<Cart> GetCarts { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
 

}