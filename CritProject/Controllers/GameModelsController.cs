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

namespace CritProject.Controllers
{
    public class GameModelsController : Controller
    {
        private CritContext db = new CritContext();

        // GET: GameModels
        public ActionResult Index()
        {
            var games = db.Games;//.Include(g => g.Producer);
            return View(games.ToList());
        }

        // GET: GameModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameModels gameModels = db.Games.Find(id);
            if (gameModels == null)
            {
                return HttpNotFound();
            }
            return View(gameModels);
        }

        // GET: GameModels/Create
        public ActionResult Create()
        {
            ViewBag.ProducerID = new SelectList(db.Producers, "ID", "CompanyName");
            return View();
        }

        // POST: GameModels/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ProducerID,RealeaseDate,Type,IsMultiplayer,Description,Picture,AvrRating,Platforms")] GameModels gameModels)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(gameModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProducerID = new SelectList(db.Producers, "ID", "CompanyName", gameModels.ProducerID);
            return View(gameModels);
        }

        // GET: GameModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameModels gameModels = db.Games.Find(id);
            if (gameModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProducerID = new SelectList(db.Producers, "ID", "CompanyName", gameModels.ProducerID);
            return View(gameModels);
        }

        // POST: GameModels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ProducerID,RealeaseDate,Type,IsMultiplayer,Description,Picture,AvrRating,Platforms")] GameModels gameModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProducerID = new SelectList(db.Producers, "ID", "CompanyName", gameModels.ProducerID);
            return View(gameModels);
        }

        // GET: GameModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameModels gameModels = db.Games.Find(id);
            if (gameModels == null)
            {
                return HttpNotFound();
            }
            return View(gameModels);
        }

        // POST: GameModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameModels gameModels = db.Games.Find(id);
            db.Games.Remove(gameModels);
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
