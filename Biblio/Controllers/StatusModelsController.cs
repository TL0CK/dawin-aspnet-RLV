using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblio.Models;

namespace Biblio.Controllers
{
    public class StatusModelsController : Controller
    {
        private StatusDBContext db = new StatusDBContext();

        // GET: StatusModels
        public ActionResult Index()
        {
            return View(db.StatusModels.ToList());
        }

        // GET: StatusModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusModels statusModels = db.StatusModels.Find(id);
            if (statusModels == null)
            {
                return HttpNotFound();
            }
            return View(statusModels);
        }

        // GET: StatusModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusModels/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ShortLibStatus,LibStatus,StartBorrowingTime,ExpectedEndBorrowingTime")] StatusModels statusModels)
        {
            if (ModelState.IsValid)
            {
                db.StatusModels.Add(statusModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusModels);
        }

        // GET: StatusModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusModels statusModels = db.StatusModels.Find(id);
            if (statusModels == null)
            {
                return HttpNotFound();
            }
            return View(statusModels);
        }

        // POST: StatusModels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ShortLibStatus,LibStatus,StartBorrowingTime,ExpectedEndBorrowingTime")] StatusModels statusModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusModels);
        }

        // GET: StatusModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusModels statusModels = db.StatusModels.Find(id);
            if (statusModels == null)
            {
                return HttpNotFound();
            }
            return View(statusModels);
        }

        // POST: StatusModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusModels statusModels = db.StatusModels.Find(id);
            db.StatusModels.Remove(statusModels);
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
