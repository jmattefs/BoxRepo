using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoxService.Models;

namespace BoxService.Controllers
{
    public class SurveyModelsController : Controller
    {
        private RegisteredUserDbContext db = new RegisteredUserDbContext();


        [HttpGet]
        public ActionResult GoToSurvey()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GoToSurvey([Bind(Include = "ID,gender,age,Money,alcohol,presentable, books, candles, candy, clothes, coffee, fitness, games, movies, music, sports, active, candle, entertainment, foodORdrink, appearance")] SurveyModel surveyModel)
        {
            if (ModelState.IsValid)
            {
                
                db.SurveyResponses.Add(surveyModel);
                db.SaveChanges();
                return RedirectToAction("Index", surveyModel);
            }

            return View("Index", surveyModel);
        }

        // GET: SurveyModels
        public ActionResult Index()
        {
            return View(db.SurveyResponses.ToList());
        }

        // GET: SurveyModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyModel surveyModel = db.SurveyResponses.Find(id);
            if (surveyModel == null)
            {
                return HttpNotFound();
            }
            return View(surveyModel);
        }

        // GET: SurveyModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SurveyModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,gender,age,Money,alcohol,presentable,books,candles,candy,clothes,coffee,fitness,games,movies,music,sports,active,candle,entertainment,foodORdrink,looks")] SurveyModel surveyModel)
        {
            if (ModelState.IsValid)
            {
                db.SurveyResponses.Add(surveyModel);
                db.SaveChanges();

                return RedirectToAction("Index");  //change "Index" to "GetCurrentSurveyResults" and add ,surveyModel
            }

            return View(surveyModel);
        }

        // GET: SurveyModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyModel surveyModel = db.SurveyResponses.Find(id);
            if (surveyModel == null)
            {
                return HttpNotFound();
            }
            return View(surveyModel);
        }

        // POST: SurveyModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,gender,age,Money,alcohol,presentable,books,candles,candy,clothes,coffee,fitness,games,movies,music,sports,active,candle,entertainment,foodORdrink,looks")] SurveyModel surveyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetSurveyResults"); //change from index to results page
            }
            return View(surveyModel);
        }

        // GET: SurveyModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyModel surveyModel = db.SurveyResponses.Find(id);
            if (surveyModel == null)
            {
                return HttpNotFound();
            }
            return View(surveyModel);
        }

        // POST: SurveyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SurveyModel surveyModel = db.SurveyResponses.Find(id);
            db.SurveyResponses.Remove(surveyModel);
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
        public ActionResult GetCurrentSurveyResults(SurveyModel sm, Box box)
        {
            int age = sm.Age;
            int money = sm.Money;
            int active = sm.Active;
            int candle = sm.Candle;
            int entertainment = sm.Entertainment;
            int foodORdrink = sm.foodORdrink;
            int looks = sm.Looks;
            int gender = sm.Gender;
            bool alcohol = sm.Alcohol;
            bool appearance = sm.Appearance;
            bool books = sm.Books;
            bool candles = sm.Candles;
            bool candy = sm.Candy;
            bool clothes = sm.Clothes;
            bool coffee = sm.Coffee;
            bool fitness = sm.Fitness;
            bool games = sm.Games;
            bool movies = sm.Movies;
            bool music = sm.Music;
            bool sports = sm.Sports;
            

            if (age > 1 && alcohol == true && gender > 1)
            {

            }
            else if (age > 1 && alcohol == true && gender < 2)
            {

            }
            else if (candle > 2 && candles == true)
            {

            }
            else if(active > 2 && fitness == true)
            {

            }
            else if(entertainment > 2 && games == true)
            {

            }
            else if (entertainment > 2 && movies == true)
            {

            }
            else if (entertainment > 2 && music == true)
            {

            }
            else if(foodORdrink > 2 && candy == true)
            {

            }
            else if(foodORdrink > 2 && coffee == true){

            }
            else if (looks > 2 && appearance == true)
            {

            }
            //db.SurveyResponses.Select(x => x).Where(x => x.Age < 21);
            return View(sm);
        }
    }
}
