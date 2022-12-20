using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLoanApp.Models.HomeLoans
{
    
        interface ILoanDetails : IDisposable
        {
            IEnumerable<LoanDetails> GetLoanDetails();
            LoanDetails GetLoanDetailsByID(int loanid);
            void InsertLoanDetails(LoanDetails loanDetails);
            void UpdateLoanDetails(LoanDetails loanDetails);
            void DeleteLoanDetails(int loanid);
            void Save();



        }
    
}
