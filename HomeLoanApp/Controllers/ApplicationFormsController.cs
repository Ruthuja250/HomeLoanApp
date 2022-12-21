using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeLoanApp.Models;
using System.Net.Mail;

namespace HomeLoanApp.Controllers
{
    public class ApplicationFormsController : Controller
    {
        private HomeLoanContext db = new HomeLoanContext();

        // GET: ApplicationForms
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.ApplicationForms.ToList());
        }

        // GET: ApplicationForms/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationForm applicationForm = db.ApplicationForms.Find(id);
            if (applicationForm == null)
            {
                return HttpNotFound();
            }
            return View(applicationForm);
        }
       
        // GET: ApplicationForms/Create
        [Authorize(Roles ="User")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Application_Id,Name,Phone_No,DOB,Email,Address,Bank_Account_No,Employeement_Type,Organization_Name,Property_Location,Property_Value,Aadharcard, PanCard ,Users_UserId")] ApplicationForm u)
        {
            /* if (ModelState.IsValid)
             {
                 db.ApplicationForms.Add(applicationForm);
                 db.SaveChanges();
                 return RedirectToAction("Index","Home");
             }*/
            {
                if (ModelState.IsValid)
                {

                    db.ApplicationForms.Add(u);

                    if (db.SaveChanges() > 0)
                    
                        ViewBag.message = "ApplicationForm Submitted Successfully";
                        MailMessage mm = new MailMessage("homeloanproject1234@gmail.com", u.Email);



                        mm.Subject = "Welcome to LoanWorth  ";
                        mm.Body = "This is your password :" + u.Application_Id.ToString() + "   and this is Username : " + u.DOB.ToString() + " you can log in now in application ";
                        mm.IsBodyHtml = false;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;



                        NetworkCredential nc = new NetworkCredential("homeloanproject1234@gmail.com", "wlyjbrcwszzwoozo");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = nc;



                        smtp.Send(mm);



                        ViewBag.message = "Thank you for Connecting with us!Your id has been sent to your regsitered mail id  ";
                      
                    return RedirectToAction("Index","home");
                    }
                }

              //  ViewBag.Message = "Successfully Registered";
                return View(u);
            }

           
        

        // GET: ApplicationForms/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationForm applicationForm = db.ApplicationForms.Find(id);
            if (applicationForm == null)
            {
                return HttpNotFound();
            }
            return View(applicationForm);
        }

        // POST: ApplicationForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Application_Id,Name,Phone_No,DOB,Address,Bank_Account_No,Employeement_Type,Organization_Name,Property_Location,Property_Value")] ApplicationForm applicationForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationForm);
        }

        // GET: ApplicationForms/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationForm applicationForm = db.ApplicationForms.Find(id);
            if (applicationForm == null)
            {
                return HttpNotFound();
            }
            return View(applicationForm);
        }

        // POST: ApplicationForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicationForm applicationForm = db.ApplicationForms.Find(id);
            db.ApplicationForms.Remove(applicationForm);
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
