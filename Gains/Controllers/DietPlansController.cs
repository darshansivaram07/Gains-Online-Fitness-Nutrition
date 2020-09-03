using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gains.Models;

namespace Gains.Controllers
{
    [HandleError]
    public class DietPlansController : Controller
    {
        private GainsContext db = new GainsContext();

      
        public ActionResult Index()
        {
            //Fetches all the Diet Plans from the Database Table dietPlansModels
            try
            {
                return View(db.dietPlansModels.ToList());
            }
            catch (Exception)
            {
                ViewBag.Message = "Something Went Wrong In The Index Section";
                return View("Error");
            }
        }

        public ActionResult DietDetails(int? id)
        {
            //Fetches the details of the selected Diet Plan 
            try
            {
                
                if (id == null)
                {
                    Response.StatusCode = 400;
                    ViewBag.Message = "Error: " + Response.StatusCode + ". Bad Request";
                    return View("Error");

                }
                DietPlansModel dietPlansModel = db.dietPlansModels.Find(id);
                if (dietPlansModel == null)
                {
                    Response.StatusCode = 404;
                    ViewBag.Message = "Error: " + Response.StatusCode + ". The requested page for DietId:" + id.Value + " is not available";
                    return View("Error");
                }
                return View(dietPlansModel);
            }
            catch (Exception)
            {
                ViewBag.Message = "Something Went Wrong In The DietDetails Section";
                return View("Error");
            }
        }

  
        public ActionResult Create()
        {
            //Displays the Create View for the  DietPlans Model
            try
            {
                return View();
            }
            catch (Exception)
            {
                ViewBag.Message = "Something Went Wrong In The Create Section";
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DietId,DietHeading,DietAuthor,DietAuthorDescription,DietCategory,DietDate,DietProfilePic,DietDetailPic,DietBody,DietSubHeading1,DietBody1,DietSubHeading2,DietBody2,DietSubHeading3,DietBody3,DietSubHeading4,DietBody4,DietSubHeading5,DietBody5,DietSubHeading6,DietBody6,DietSubHeading7,DietBody7")] DietPlansModel dietPlansModel)
        {
            //Adds new Diet Plans to the Database Table dietPlansModel
            try
            {
                if (ModelState.IsValid)
                {
                    db.dietPlansModels.Add(dietPlansModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(dietPlansModel);
            }
            catch (Exception)
            {
                ViewBag.Message = "Something Went Wrong In The Create Section";
                return View("Error");
            }
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
