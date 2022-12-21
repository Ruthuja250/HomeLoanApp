using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeLoanApp.Models.HomeLoans;

namespace HomeLoanApp.Models
{

    public class LoanDetails
    {
        [Key]
        public int Application_Id { get; set; }
        public string Name { get; set; }
        [Required]
        public double LoanAmount { get; set; }
        [Required]
        public double InterestRate { get; set; }
        [Required]
        public string LoanStatus { get; set; }
        [Required]
        public double Tenure { get; set; }
        
        
        }
    }


