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
    public class CriticModelsController : Controller
    {
        private CritContext db = new CritContext();

        // GET: CriticModels
        public ActionResult Index()
        {
            return View(db.Critics.ToList());
        }

        // GET: CriticModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriticModels criticModels = db.Critics.Find(id);
            if (criticModels == null)
            {
                return HttpNotFound();
            }
            return View(criticModels);
        }

        // GET: CriticModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CriticModels/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,SecondName,Alias,Picture,Descritpion,Appreciation")] CriticModels criticModels)
        {
            if (ModelState.IsValid)
            {
                db.Critics.Add(criticModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(criticModels);
        }

        // GET: CriticModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriticModels criticModels = db.Critics.Find(id);
            if (criticModels == null)
            {
                return HttpNotFound();
            }
            return View(criticModels);
        }

        // POST: CriticModels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,SecondName,Alias,Picture,Descritpion,Appreciation")] CriticModels criticModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criticModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(criticModels);
        }

        // GET: CriticModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriticModels criticModels = db.Critics.Find(id);
            if (criticModels == null)
            {
                return HttpNotFound();
            }
            return View(criticModels);
        }

        // POST: CriticModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CriticModels criticModels = db.Critics.Find(id);
            db.Critics.Remove(criticModels);
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
