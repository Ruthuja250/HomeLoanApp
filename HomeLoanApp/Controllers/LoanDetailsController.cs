using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeLoanApp.Models;
using HomeLoanApp.Models.HomeLoans;

namespace HomeLoanApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class LoanDetailsController : Controller
    {

       
        private ILoanDetails obj;
            public LoanDetailsController()
            {
                this.obj = new LoanDetailsRepo(new Models.HomeLoanContext());
            }
            // GET: LoanDetails
            public ActionResult Index()
            {

            var Data = from n in obj.GetLoanDetails() select n;
            return View(Data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LoanDetails loanDetails)
        {
            obj.InsertLoanDetails(loanDetails);
            obj.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
            {
                LoanDetails l = obj.GetLoanDetailsByID(id);
                return View(l);
            }
            public ActionResult Delete(int id)
            {
                LoanDetails l = obj.GetLoanDetailsByID(id);
                return View(l);
            }
            [HttpPost]
            public ActionResult Delete(int id, LoanDetails l)
            {
                obj.DeleteLoanDetails(id);
                obj.Save();
                return RedirectToAction("Index");
            }
            public ActionResult Edit(int id)
            {
                LoanDetails l = obj.GetLoanDetailsByID(id);
                return View(l);
            }
            [HttpPost]
            public ActionResult Edit(int id, LoanDetails loandetails)
            {
                obj.UpdateLoanDetails(loandetails);
                obj.Save();
                return RedirectToAction("Index");
            }
        }
    }
