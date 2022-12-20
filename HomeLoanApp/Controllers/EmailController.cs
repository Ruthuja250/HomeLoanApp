using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 using HomeLoanApp.Models;
using System.Net;
using System.Net.Mail;


namespace HomeLoanApp.Controllers
{
       [Authorize(Roles ="Admin")]
    public class EmailController : Controller
    {
        // GET: Email
       
        public ActionResult EmailIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmailIndex(HomeLoanApp.Models.Email model)
        {
            MailMessage mn = new MailMessage("homeloanproject1234@gmail.com", model.To);
            mn.Subject = model.Subject;
            mn.Body = model.Body;
            mn.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("homeloanproject1234@gmail.com", "wlyjbrcwszzwoozo");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mn);
            ViewBag.Message = "Mail has been sent successfully ";


            return View();
        }
    }
}
   