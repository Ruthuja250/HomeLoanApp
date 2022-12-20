using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;
using HomeLoanApp.Models.HomeLoans;


namespace HomeLoanApp.Models.HomeLoans
{
    public class LoanDetailsRepo : ILoanDetails
    {
        
            public HomeLoanContext _acontext;
            public LoanDetailsRepo(HomeLoanContext context)
            {
                this._acontext = context;
            }



            public void DeleteLoanDetails(int loanid)
            {
                LoanDetails loandetails = _acontext.LoanDetailss.Find(loanid);
                _acontext.LoanDetailss.Remove(loandetails);
            }



            public void Dispose()
            {
                throw new NotImplementedException();
            }
             public LoanDetails GetLoanDetailsByID(int loanid)
             {
            return _acontext.LoanDetailss.Find(loanid);
               }
             public IEnumerable<LoanDetails> GetLoanDetails()
            {
                return _acontext.LoanDetailss.ToList();
            }



            public void InsertLoanDetails(LoanDetails loanDetails)
            {
                _acontext.LoanDetailss.Add(loanDetails);
            }
        public void Save()
        {
            _acontext.SaveChanges();
        }

        public void UpdateLoanDetails(LoanDetails loanDetails)
            {
                _acontext.Entry(loanDetails).State = System.Data.Entity.EntityState.Modified;
            }
        }
    }
