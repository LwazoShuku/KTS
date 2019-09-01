using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace KTS.Models
{
    public class Employee
    {
        [Key]
        [Display(Name = "Employee Number")]
        [Required(ErrorMessage = "Enter employee number")]
        public string EmpNo { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Name")]
        [Display(Name = "Employee Name")]
        public string EName { get; set; }

        [Display(Name = "Identity number")]
        [Required(ErrorMessage = "Enter Employee ID")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Surname")]
        [Display(Name = "Employee Surname")]
        public string EsName { get; set; }

        [Display(Name ="Bank Acc Number")]
        [Required(ErrorMessage ="Enter Bank Acc Number")]
        public int BankAccNo { get; set; }

        [Required(ErrorMessage ="Enter Branch code")]
        [Display(Name ="Branch code")]
        public string BranchCode { get; set; } 

        [Required(ErrorMessage = "Enter address")]
        [Display(Name = "Address")]
        public string Eaddress { get; set; }


        [Required(ErrorMessage = "Enter Cell No")]
        [Display(Name = "Cell number")]
        public int Ecell { get; set; }

        [Required(ErrorMessage = "Enter fascimile contact")]
        [Display(Name = "Fascimile")]
        public int FascimleContact { get; set; }

        [Required(ErrorMessage = "Enter Tax NO")]
        [Display(Name = "Tax Number")]
        public int taxNo { get; set; }



        public List<Contract> contracts { get; set; }
    }
}