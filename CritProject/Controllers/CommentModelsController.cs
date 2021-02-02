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
    public class CommentModelsController : Controller
    {
        private CritContext db = new CritContext();

        // GET: CommentModels
        public ActionResult Index()
        {
            return View(db.Comments.ToList());
        }

        // GET: CommentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentModels commentModels = db.Comments.Find(id);
            if (commentModels == null)
            {
                return HttpNotFound();
            }
            return View(commentModels);
        }

        // GET: CommentModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommentModels/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ReviewID,Text,OwnerName,CommentDate")] CommentModels commentModels)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(commentModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commentModels);
        }


        public ActionResult CreateFromReview([Bind(Include = "ID,ReviewID,Text,OwnerName,CommentDate")] CommentModels commentModels)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            commentModels.CommentDate = dateTime;
            commentModels.ReviewID = 1;

            if (ModelState.IsValid)
            {
                db.Comments.Add(commentModels);
                db.SaveChanges();
                return RedirectToAction("Index", "ReviewModels", new { area = "" });
            }

            return View(commentModels);
        }

        // GET: CommentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentModels commentModels = db.Comments.Find(id);
            if (commentModels == null)
            {
                return HttpNotFound();
            }
            return View(commentModels);
        }

        // POST: CommentModels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ReviewID,Text,OwnerName,CommentDate")] CommentModels commentModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commentModels);
        }

        // GET: CommentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentModels commentModels = db.Comments.Find(id);
            if (commentModels == null)
            {
                return HttpNotFound();
            }
            return View(commentModels);
        }

        // POST: CommentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentModels commentModels = db.Comments.Find(id);
            db.Comments.Remove(commentModels);
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
