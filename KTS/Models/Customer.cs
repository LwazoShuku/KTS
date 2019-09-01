using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
namespace KTS.Models
{
    public class Customer
    {
        [Key]
       public int cID { get; set; }

        
        public string CustomerEmail {get;set;}




    }
}