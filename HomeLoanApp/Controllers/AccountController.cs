using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HomeLoanApp.Models;

namespace HomeLoanApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public HomeLoanContext db = new HomeLoanContext();
        // GET: register
       
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users u)
        {
            if (ModelState.IsValid)
            {

                db.Userss.Add(u);
                
                if (db.SaveChanges() > 0)
                {
                    ViewBag.message = "Registered Successfully";
                    return RedirectToAction("Login");
                }
            }

            ViewBag.Message = "Successfully Registered";
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users u, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = db.Userss.Where(x => x.Email == u.Email && x.Password == u.Password).ToList();
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(u.Email, false);
                    Session["Email"] = u.Email.ToString();
                    Session["Password"] = u.Password.ToString();
                }
                
                    if(ReturnUrl!=null)
                    {
                    
                        return Redirect(ReturnUrl);
                      

                    }
               
                else
                {

                    return RedirectToAction("Index","Home");

                }
            }
            return View();

        }
        public ActionResult Logout()

        {
            FormsAuthentication.SignOut();
            Session["email"] = null;

            return RedirectToAction("Login");

        }
    }
}