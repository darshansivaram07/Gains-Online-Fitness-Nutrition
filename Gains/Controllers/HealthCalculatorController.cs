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
    public class HealthCalculatorController : Controller
    {
        string name;
        int age;
        string gender;
        double height;
        double weight;
        double waist;
        double hip;
        double bmi;
        string bmiresult;
        double wsr;
        string wsrresult;
        string goalcategory;

        private GainsContext db = new GainsContext();
        List<SelectListItem> UnitTypes = new List<SelectListItem>()
        {
            //Drop down values to be displayed in the Calculator View 
            new SelectListItem(){Value="Metric",Text="Metric(cm/kg)"},
            new SelectListItem(){Value="American",Text="American(in/lb)"},
        };

        public ActionResult DietDetails(int? id)
        {
            //Fetches the details of the selected Diet Plan from the suggested Diet Plans
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
        public ActionResult WorkoutDetails(int? id)
        {
            //Fetches the details of the selected Workout Plan from the suggested Workout Plans
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
                    ViewBag.Message = "Error: " + Response.StatusCode + ". The requested page for workoutId:" + id.Value + " is not available";
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

        public ActionResult Calculator()
        {
            //Displays the Calculator View
            try
            {
                
                ViewBag.UnitTypes = UnitTypes;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Message = "Something Went Wrong In The Calculator Section";
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculator([Bind(Include = "Id,Name,Gender,Age,Unit,Height,Weight,Waist,Hip,BMIValue,BMIResult,WSRValue,WSRResult,GoalCategory")] HealthCalculatorModel healthCalculatorModel)
        {
            //Calculates BMI, WSR and gets client information and displays in the Result View
            try
            {
                CalculateBMI();
                CalculateWSR();
                GeneralInfo();
                Result();
                return View("Result");
            }
            catch (Exception)
            {
                ViewBag.Message = "Something Went Wrong In The Calculator Section";
                return View("Error");
            }

        }
        public void CalculateBMI()
        {
            //Claculates BMI value for the client based on the selected unit and assigns goal-category to them
            height = Convert.ToDouble(Request.Form["Height"]);
            weight = Convert.ToDouble(Request.Form["Weight"]);
            string unit = Request.Form["Unit"];

            if (unit == "Metric")
            {
                bmi = Math.Round((weight / (height * height * 0.0001)), 1);

            }
            else
            {
                bmi = Math.Round((703.0 * weight) / (height * height), 1);
            }
            ViewBag.BMIValue = bmi;
            if (bmi <= 18.5)
            {
                bmiresult = "UnderWeight";
                goalcategory = "Weight-Gain";
                TempData["goalcategory"] = "Weight-Gain";
            }
            else if (bmi >= 18.5 && bmi <= 24.9)
            {
                bmiresult = "Healthy";
                goalcategory = "Fitness";
                TempData["goalcategory"] = "Fitness";
            }
            else if (bmi >= 25.0 && bmi <= 29.9)
            {
                bmiresult = "OverWeight";
                goalcategory = "Weight-Loss";
                TempData["goalcategory"] = "Weight-Loss";
            }
            else if (bmi >= 30.0)
            {
                bmiresult = "Obese";
                goalcategory = "Weight-Loss";
                TempData["goalcategory"] = "Weight-Loss";
            }
        }
        public void CalculateWSR()
        {
            //Calculates WSR value for the client based on the selected gender
            waist = Convert.ToDouble(Request.Form["Waist"]);
            hip = Convert.ToDouble(Request.Form["Hip"]);
            wsr = Math.Round((waist / hip), 2);
            gender = Request.Form["Gender"];

            if (gender == "Male")
            {
                if (wsr <= 0.95)
                {
                    wsrresult = "Low";
                }
                else if (wsr >= 0.96 && wsr <= 1.0)
                {
                    wsrresult = "Moderate";
                }
                else if (wsr >= 1.1)
                {
                    wsrresult = "High";
                }

            }
            else if (gender == "Female")
            {
                if (wsr <= 0.80)
                {
                    wsrresult = "Low";
                }
                else if (wsr >= 0.81 && wsr <= 0.85)
                {
                    wsrresult = "Moderate";
                }
                else if (wsr >= 0.86)
                {
                    wsrresult = "High";
                }

            }
        }
        public void GeneralInfo()
        {
            //Fetches general information of the client for the result view
            name = Request.Form["Name"];
            age = Convert.ToInt32(Request.Form["Age"]);
            gender = Request.Form["Gender"];
        }

        public void Result()
        {
            //Fetches value for the Result View
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Height = height;
            ViewBag.Weight = weight;
            ViewBag.Waist = waist;
            ViewBag.Hip = hip;
            ViewBag.BMI = bmi;
            ViewBag.BMICategory = bmiresult;
            ViewBag.WSRValue = wsr;
            ViewBag.WSRCategory = wsrresult;
            ViewBag.Goal = goalcategory;
            if (bmiresult == "UnderWeight")
            {
                ViewBag.BMIResult = "You are UnderWeight. Have a healthy diet and do exercise to improve your BMI.";
            }
            else if (bmiresult == "Healthy")
            {
                ViewBag.BMIResult = "Congrats!! You have a Healthy Weight.";

            }
            else if (bmiresult == "OverWeight")
            {
                ViewBag.BMIResult = "Oops!! You are OverWeight. Have a healthy diet and do exercise to improve your BMI.";

            }
            else if (bmiresult == "Obese")
            {
                ViewBag.BMIResult = "Oops!! You are Obese. Have a healthy diet and do exercise to improve your BMI.";

            }
            if (wsrresult == "Low")
            {
                ViewBag.WSRResult = "Your health risk is very Low.";
            }
            else if (wsrresult == "Moderate")
            {
                ViewBag.WSRResult = "Your health risk is Moderate.";
            }
            else if (wsrresult == "High")
            {
                ViewBag.WSRResult = "Your health risk is very High.";
            }

        }
    
           
        
        public ActionResult SuggestedDietPlans()
        {
            //Fetches all the suggested Diet Plans based on the value of BMI 
            try
            {
                string category = (string)TempData["goalcategory"];
                TempData.Keep();
                var dietplans = db.dietPlansModels.ToList();
                List<DietPlansModel> dietPlans = null;
                if (category == "Weight-Gain")
                {
                    dietPlans = dietplans.FindAll(ob => ob.DietCategory == category).ToList();
                }
                else if (category == "Fitness")
                {
                    dietPlans = dietplans.FindAll(ob => ob.DietCategory == category).ToList();
                }
                else if (category == "Weight-Loss")
                {
                    dietPlans = dietplans.FindAll(ob => ob.DietCategory == category).ToList();
                }
                return View("SuggestedDietPlans", dietPlans);
            }
            catch (Exception)
            {
                ViewBag.Message = "Something Went Wrong In The Sugeested DietPlans Section";
                return View("Error");
            }
        }
        public ActionResult SuggestedWorkoutPlans()
        {
            //Fetches all the suggested Workout Plans based on the value of BMI 
            try
            {
                string category = (string)TempData["goalcategory"];
                TempData.Keep();
                var workoutplans = db.workoutPlansModels.ToList();
                List<WorkoutPlansModel> workoutPlans = null;
                if (category == "Weight-Gain")
                {
                    workoutPlans = workoutplans.FindAll(ob => ob.WorkoutCategory == category).ToList();
                }
                else if (category == "Fitness")
                {
                    workoutPlans = workoutplans.FindAll(ob => ob.WorkoutCategory == category).ToList();
                }
                else if (category == "Weight-Loss")
                {
                    workoutPlans = workoutplans.FindAll(ob => ob.WorkoutCategory == category).ToList();
                }
                return View("SuggestedWorkoutPlans", workoutPlans);
            }
            catch (Exception)
            {
                ViewBag.Message = "Something Went Wrong In The Suggested WorkoutPlans Section";
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
