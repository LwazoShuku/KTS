using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
namespace KTS.Models
{
    public class Services
    {
        [Key]
        public string Serviceid { get; set; }

        [Display(Name ="Price")]
        public decimal price { get; set; }

        public string productTy { get; set; }
        public ProductType GetProductType { get; set; }



    }
}