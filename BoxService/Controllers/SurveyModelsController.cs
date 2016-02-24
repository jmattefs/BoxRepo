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
        public ActionResult GoToSurvey([Bind(Include = "ID,gender,age,maxMoney,alcohol,presentable, books, candles, candy, clothes, coffee, fitness, games, movies, music, sports, active, candle, entertainment, foodORdrink, appearance")] SurveyModel surveyModel)
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
        public ActionResult Create([Bind(Include = "ID,gender,age,maxMoney,alcohol,presentable,books,candles,candy,clothes,coffee,fitness,games,movies,music,sports,active,candle,entertainment,foodORdrink,appearance")] SurveyModel surveyModel)
        {
            if (ModelState.IsValid)
            {
                db.SurveyResponses.Add(surveyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
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
        public ActionResult Edit([Bind(Include = "ID,gender,age,maxMoney,alcohol,presentable,books,candles,candy,clothes,coffee,fitness,games,movies,music,sports,active,candle,entertainment,foodORdrink,appearance")] SurveyModel surveyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
    }
}
