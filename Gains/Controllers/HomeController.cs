using Gains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Gains.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private GainsContext db = new GainsContext();
        
        public ActionResult Index()
        {
            //Displays the Home page 
            try
            {
                return View();
            }
            catch (Exception)
            {
                ViewBag.Message = "Something Went Wrong In The Index Section";
                return View("Error");
            }
        }
        public ActionResult Contact()
        {
            //Displays the Contact page
            try {
                return View();
            }
            catch (Exception)
            {
                ViewBag.Message = "Something Went Wrong In The Contact Section";
                return View("Error");
            }

        }
        
        [HttpPost]
        public ActionResult Contact([Bind(Include = "UserId,UserFirstName,UserLastName,UserPhoneNumber,UserEmailId")]  UserInformationModel userInformationModel)
        {
            //Stores user information to the database and sends a welcome e-mail to the provided email-id
            try
            {
                string from = "gainsfitness07@gmail.com";
                if (ModelState.IsValid)
                {

                    db.userInformationModels.Add(userInformationModel);
                    db.SaveChanges();
                    MailMessage mail = new MailMessage(from, userInformationModel.UserEmailId);
                    mail.Subject = "Signing Up Bonus";
                    string Body = "Hi " + userInformationModel.UserFirstName + " " + userInformationModel.UserLastName +"." +"<br/>";
                    Body += "Thank you for subscribing to us!!" + "<br/>";
                    Body += "As a token of appreciation here is a free copy of our customised workout plans." + "<br/>";
                    Body += "https://docdro.id/f727g0l";
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("gainsfitness07@gmail.com", "GainsFitness@07"); // Enter seders User name and password   
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    ViewBag.Success = String.Format("Email has been sent to the provided email-id: {0}", userInformationModel.UserEmailId);
                    return View();
                }

                return View();
            }
            catch (Exception)
            {
                ViewBag.Message = "Something Went Wrong In The Contact Section";
                return View("Error");
            }

        }
        public ActionResult PageNotFound()
        {
            //Returns View for Error: 404
            return View();
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