﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using HomeLoanApp.Models;


namespace HomeLoanApp.Controllers
{
   
    public class HomeController : Controller
    {
        public HomeLoanContext db = new HomeLoanContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

       
        public ActionResult Calculator()
        {
            ViewBag.Message = "Your calculator page.";

            return View();
        }

        public ActionResult account()
        {
            var UserId = (int)Session["UserId"];
           var LoanData = db.Userss.Where(t =>t.UserId==UserId).FirstOrDefault();
           
          
               return View(LoanData);
            }
           
           
        
   //     //[HttpGet]
   //     //public ActionResult account()
   //     //{

   //     //}


   ///*  public ActionResult LoanApproveDetails()
   //     {
   //         if(Session["ReferenceId"]!=null)
   //         {
   //             return RedirectToAction("approvedetails");
   //         }
   //         else 
   //             {
   //             ViewBag("","application form is in process");

   //              }
   //         return View();


   //     }*/

      //  public ActionResult approvedetails()
      //  {
      //     if (ModelState.IsValid)
      //      {
      //          var data = db.LoanDetailss.Where(x => x.Reference_Id == "").ToList();
      //          return View(data);
      //     }
      //      else
      //      {
      //          ViewBag("", "application form is in process");

      //     }
           
      //     return View();
                
      ////  }
       
        public ActionResult FAQ()
        {
            ViewBag.Message = "Your FAQ page.";

            return View();
        }
        public ActionResult LoanTracker()
        {
            ViewBag.Message = "Your calculator page.";

            return View();
        }

    }
}