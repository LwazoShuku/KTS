using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KTS.Models;
using KTS.Controllers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace KTS.Models
{
    public class Cart
    {
    
   

        public int Quantity { get; set; }

        public Inventory Inv { get; set; }

        public string shipping { get; set; }

        public string selectedtext { get; set; }
       
        public Cart(Inventory inventory, int quantity)
        {
            Inv= inventory;
            Quantity = quantity;
        
        }



        public string ship()
        {

            return selectedtext;
        }
    }

}