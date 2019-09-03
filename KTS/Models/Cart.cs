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
    
        public int id { get; set; }

        public int Quantity { get; set; }

        public Products Products { get; set; }

       
        public Cart(Products products, int quantity)
        {
            Products = products;
            Quantity = quantity;

        }



    }

}