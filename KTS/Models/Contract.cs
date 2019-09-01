using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Threading.Tasks;


namespace KTS.Models
{
    public class Contract
    {
        [Key]
        [Display(Name ="Contract Number")]
        [Required(ErrorMessage ="Enter Contract Number")]
       public string ContractID { get; set; }

        [Display(Name = "Type Of Contract")]
        [Required(ErrorMessage = "Choose a contract type")]
        public string ContractType { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Enter Contract Number")]
        public string ContractDesc { get; set; }

        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "Enter Contract Number")]
       public string JobTitle { get; set; }

        [Display(Name = "Enter Rate Per Hour")]
        [Required(ErrorMessage = "Enter Contract Number")]
        public double RPH { get; set; }

        [Display(Name = "Contract Number")]
        [Required(ErrorMessage = "Enter Contract Number")]
       public string ContractStart { get; set; }

        [Display(Name = "Contract status")]
        [Required(ErrorMessage = "choose contract Status")]
       public string status { get; set; }




        public string EmpNO { get; set; }
    public Employee Employee { get; set; }

      

    }
    public class SelectType
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }


}