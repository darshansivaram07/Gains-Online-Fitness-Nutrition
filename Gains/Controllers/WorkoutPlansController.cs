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
    public class WorkoutPlansController : Controller
    {
        private GainsContext db = new GainsContext();

      
        public ActionResult Index()
        {
            //Fetches all the Workout Plans from the Database Table workoutPlansModels
            try
            {
                return View(db.workoutPlansModels.ToList());
            }
            catch (Exception)
            {
                ViewBag.Message = "Something Went Wrong In The Index Section";
                return View("Error");
            }
        }


        public ActionResult WorkoutDetails(int? id)
        {
            //Fetches the details of the selected Workout Plan 
            try
            {
                if (id == null)
                {
                    Response.StatusCode = 400;
                    ViewBag.Message = "Error: " + Response.StatusCode + ". Bad Request";
                    return View("Error");
                }
                WorkoutPlansModel workoutPlansModel = db.workoutPlansModels.Find(id);
                if (workoutPlansModel == null)
                {
                    Response.StatusCode = 404;
                    ViewBag.Message = "Error: " + Response.StatusCode + ". The requested page for workoutId:"+id.Value +" is not available";
                    return View("Error");
                }
                return View(workoutPlansModel);
            }
            catch (Exception)
            {
                ViewBag.Message = "Something Went Wrong In The WorkoutDetails Section";
                return View("Error");
            }
        }

        public ActionResult Create()
        {
            //Displays the Create View for the  WorkoutPlans Model
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
        public ActionResult Create([Bind(Include = "WorkoutId,WorkoutHeading,WorkoutAuthor,WorkoutAuthorDescription,WorkoutCategory,WorkoutDate,WorkoutProfilePic,WorkoutDetailPic,WorkoutBody,WorkoutSubHeading1,WorkoutBody1,WorkoutSubHeading2,WorkoutBody2,WorkoutSubHeading3,WorkoutBody3,WorkoutSubHeading4,WorkoutBody4,WorkoutSubHeading5,WorkoutBody5,WorkoutSubHeading6,WorkoutBody6,WorkoutSubHeading7,WorkoutBody7")] WorkoutPlansModel workoutPlansModel)
        {
            //Adds new Workout Plans to the Database Table workoutPlansModel
            try
            {
                if (ModelState.IsValid)
                {
                    db.workoutPlansModels.Add(workoutPlansModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(workoutPlansModel);
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
