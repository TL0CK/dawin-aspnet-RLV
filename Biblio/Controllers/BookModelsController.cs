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
    public class BookModelsController : Controller
    {
        private BookDBContext db = new BookDBContext();

        // GET: BookModels
        public ActionResult Index()
        {
            return View(db.BookModels.ToList());
        }

        // GET: BookModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookModels bookModels = db.BookModels.Find(id);
            if (bookModels == null)
            {
                return HttpNotFound();
            }
            return View(bookModels);
        }

        // GET: BookModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookModels/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OwnershipDate")] BookModels bookModels)
        {
            if (ModelState.IsValid)
            {
                db.BookModels.Add(bookModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookModels);
        }

        // GET: BookModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookModels bookModels = db.BookModels.Find(id);
            if (bookModels == null)
            {
                return HttpNotFound();
            }
            return View(bookModels);
        }

        // POST: BookModels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OwnershipDate")] BookModels bookModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookModels);
        }

        // GET: BookModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookModels bookModels = db.BookModels.Find(id);
            if (bookModels == null)
            {
                return HttpNotFound();
            }
            return View(bookModels);
        }

        // POST: BookModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookModels bookModels = db.BookModels.Find(id);
            db.BookModels.Remove(bookModels);
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
