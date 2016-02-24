using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BoxService.Models;

namespace BoxService.Controllers
{
    public class SurveyController : Controller
    {
        private RegisteredUserDbContext db = new RegisteredUserDbContext();
        // GET: Survey
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GoToSurvey()
        {
            return View("Survey");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GoToSurvey([Bind(Include = "ID,gender,age,maxMoney,alcohol,presentable, books, candles, candy, clothes, coffee, fitness, games, movies, music, sports, active, candle, entertainment, foodORdrink, appearance")] SurveyModel surveyModel)
        {
            if (ModelState.IsValid)
            {
                db.SurveyResponses.Add(surveyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index", surveyModel);
        }
        

    }
}