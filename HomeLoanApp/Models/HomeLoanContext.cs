using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HomeLoanApp.Models
{
    public class HomeLoanContext: DbContext
    {
        
            public HomeLoanContext() : base("name=LoanDB")
            {
            }
            public DbSet<Users> Userss { get; set; }
             public DbSet<ApplicationForm> ApplicationForms { get; set; }
        public DbSet<LoanDetails> LoanDetailss { get; set; }



    }
}