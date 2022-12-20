using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeLoanApp.Models;

namespace HomeLoanApp.Models
{

    public class LoanDetails
    {

            [Key]
            public int LoanId { get; set; }
           
            public int? Application_Id { get; set; }
            [ForeignKey("Application_Id")]
            public virtual ApplicationForm ApplicationForms { get; set; }
            [Required]

             public int? UserId { get; set; }
             [ForeignKey("UserId")]
             public virtual Users Userss { get; set; }

             [Required]
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


