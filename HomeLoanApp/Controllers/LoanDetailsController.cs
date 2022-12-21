using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeLoanApp.Models;

namespace HomeLoanApp.Controllers
{
    
    public class LoanDetailsController : Controller
    {
        private HomeLoanContext db = new HomeLoanContext();

        // GET: LoanDetails
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.LoanDetailss.ToList());
        }

        // GET: LoanDetails/Details/5
        [Authorize(Roles ="User,Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanDetails loanDetails = db.LoanDetailss.Find(id);
            if (loanDetails == null)
            {
                return HttpNotFound();
            }
            return View(loanDetails);
        }

        // GET: LoanDetails/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Application_Id,Loanid,Name,LoanAmount,InterestRate,LoanStatus,Tenure")] LoanDetails loanDetails)
        {
            if (ModelState.IsValid)
            {
                db.LoanDetailss.Add(loanDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loanDetails);
        }

        // GET: LoanDetails/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanDetails loanDetails = db.LoanDetailss.Find(id);
            if (loanDetails == null)
            {
                return HttpNotFound();
            }
            return View(loanDetails);
        }

        // POST: LoanDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Application_Id,Loanid,Name,LoanAmount,InterestRate,LoanStatus,Tenure")] LoanDetails loanDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loanDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loanDetails);
        }

        // GET: LoanDetails/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanDetails loanDetails = db.LoanDetailss.Find(id);
            if (loanDetails == null)
            {
                return HttpNotFound();
            }
            return View(loanDetails);
        }

        // POST: LoanDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoanDetails loanDetails = db.LoanDetailss.Find(id);
            db.LoanDetailss.Remove(loanDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
