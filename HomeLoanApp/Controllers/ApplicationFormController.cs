
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeLoanApp.Models;

 
namespace HomeLoanApp.Controllers
{
   
    public class ApplicationFormController : Controller
    {
        private HomeLoanContext db = new HomeLoanContext();
        // GET: Home
       

       
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            return View(db.ApplicationForms.ToList());
        }
        [Authorize(Roles ="")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include ="ApplicationId,Name,Phone_No,DOB,Address,Bank_Account_No,Employeement_Type,Organization_Name,Property_Location,Property_value")] ApplicationForm application, HttpPostedFileBase image1*/ApplicationForm application)
        {
            if (ModelState.IsValid)
            {
                
                db.ApplicationForms.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();




        }


        public ActionResult Details(int id)
        {
           
            return View();
        }
        public ActionResult Delete(int id)
        {
          
            return View();

        }
        [HttpPost]
        public ActionResult Delete(int id, ApplicationForm a)
        {
           
            return RedirectToAction("Index");

        }
        public ActionResult Edit(int id)
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, ApplicationForm application)
        {
           
            return RedirectToAction("Index");
        }
    }
}

