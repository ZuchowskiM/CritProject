using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CritProject.DAL;
using CritProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CritProject.Controllers;

namespace CritProject.Controllers
{
    public class ReviewModelsController : Controller
    {
        private CritContext db = new CritContext();

        // GET: ReviewModels1
        public ActionResult Index(string searchString)
        {

            var reviews = from g in db.Reviews select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                reviews = reviews.Where(s => s.Game.Title.Contains(searchString)).Include(r => r.Critic).Include(r => r.Game);
            }

            //reviews = db.Reviews.Include(r => r.Critic).Include(r => r.Game);
            return View(reviews.ToList());
        }

        // GET: ReviewModels1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewModels reviewModels = db.Reviews.Find(id);
            if (reviewModels == null)
            {
                return HttpNotFound();
            }
            return View(reviewModels);
        }

        // GET: ReviewModels1/Create
        [Authorize(Roles = "critic")]
        public ActionResult Create()
        {
            ViewBag.CriticID = new SelectList(db.Critics, "ID", "Name");
            ViewBag.GameID = new SelectList(db.Games, "ID", "Title");
            return View();
        }

        // POST: ReviewModels1/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ReviewTitle,PublishDate,ReviewText,CriticID,GameID,Rating")] ReviewModels reviewModels)
        {
            reviewModels.PublishDate = DateTime.Now;

            string userID = User.Identity.GetUserId();

            var critic = db.Critics.Where(c => c.SecondName.Equals(userID));
            

            reviewModels.CriticID = critic.FirstOrDefault().ID;

            if (ModelState.IsValid)
            {
                db.Reviews.Add(reviewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriticID = new SelectList(db.Critics, "ID", "Name", reviewModels.CriticID);
            ViewBag.GameID = new SelectList(db.Games, "ID", "Title", reviewModels.GameID);
            return View(reviewModels);
        }

        // GET: ReviewModels1/Edit/5
        [Authorize(Roles = "critic")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewModels reviewModels = db.Reviews.Find(id);
            if (reviewModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriticID = new SelectList(db.Critics, "ID", "Name", reviewModels.CriticID);
            ViewBag.GameID = new SelectList(db.Games, "ID", "Title", reviewModels.GameID);
            return View(reviewModels);
        }

        // POST: ReviewModels1/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ReviewTitle,PublishDate,ReviewText,CriticID,GameID,Rating")] ReviewModels reviewModels)
        {
            reviewModels.PublishDate = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                db.Entry(reviewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriticID = new SelectList(db.Critics, "ID", "Name", reviewModels.CriticID);
            ViewBag.GameID = new SelectList(db.Games, "ID", "Title", reviewModels.GameID);
            return View(reviewModels);
        }

        // GET: ReviewModels1/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewModels reviewModels = db.Reviews.Find(id);
            if (reviewModels == null)
            {
                return HttpNotFound();
            }
            return View(reviewModels);
        }

        // POST: ReviewModels1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReviewModels reviewModels = db.Reviews.Find(id);
            db.Reviews.Remove(reviewModels);
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
