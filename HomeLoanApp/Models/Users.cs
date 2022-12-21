using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeLoanApp.Models
{
    public class Users
    {
        public Users()
        {
            this.ApplicationForms = new HashSet<ApplicationForm>();
        }

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "please confirnm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
        public virtual ICollection<ApplicationForm> ApplicationForms { get; set; }
    }
}