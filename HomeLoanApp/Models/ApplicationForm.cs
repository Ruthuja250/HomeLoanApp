using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeLoanApp.Models;

namespace HomeLoanApp.Models
{
    public class ApplicationForm
    {
         [Key]
        public int Application_Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone_No { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Bank_Account_No { get; set; }
        [Required]
        public string Employeement_Type { get; set; }
        [Required]
        public string Organization_Name { get; set; }
        [Required]
        public string Property_Location { get; set; }
        [Required]
        public double Property_Value { get; set; }
        [Required]
        public int Aadharcard { get; set; }
        [Required]
        public int PanCard { get; set; }
        public virtual Users Users { get; set; }
       

    }
}