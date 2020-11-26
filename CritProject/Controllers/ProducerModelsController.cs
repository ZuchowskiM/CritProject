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
    public class ProducerModelsController : Controller
    {
        private CritContext db = new CritContext();

        // GET: ProducerModels
        public ActionResult Index()
        {
            return View(db.Producers.ToList());
        }

        // GET: ProducerModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerModels producerModels = db.Producers.Find(id);
            if (producerModels == null)
            {
                return HttpNotFound();
            }
            return View(producerModels);
        }

        // GET: ProducerModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducerModels/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyName,Value,HQPlace")] ProducerModels producerModels)
        {
            if (ModelState.IsValid)
            {
                db.Producers.Add(producerModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producerModels);
        }

        // GET: ProducerModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerModels producerModels = db.Producers.Find(id);
            if (producerModels == null)
            {
                return HttpNotFound();
            }
            return View(producerModels);
        }

        // POST: ProducerModels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyName,Value,HQPlace")] ProducerModels producerModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producerModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producerModels);
        }

        // GET: ProducerModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerModels producerModels = db.Producers.Find(id);
            if (producerModels == null)
            {
                return HttpNotFound();
            }
            return View(producerModels);
        }

        // POST: ProducerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProducerModels producerModels = db.Producers.Find(id);
            db.Producers.Remove(producerModels);
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
