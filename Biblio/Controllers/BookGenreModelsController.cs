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
    public class BookGenreModelsController : Controller
    {
        private BookGenreDBContext db = new BookGenreDBContext();

        // GET: BookGenreModels
        public ActionResult Index()
        {
            return View(db.BookGenreModels.ToList());
        }

        // GET: BookGenreModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookGenreModels bookGenreModels = db.BookGenreModels.Find(id);
            if (bookGenreModels == null)
            {
                return HttpNotFound();
            }
            return View(bookGenreModels);
        }

        // GET: BookGenreModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookGenreModels/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Genre")] BookGenreModels bookGenreModels)
        {
            if (ModelState.IsValid)
            {
                db.BookGenreModels.Add(bookGenreModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookGenreModels);
        }

        // GET: BookGenreModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookGenreModels bookGenreModels = db.BookGenreModels.Find(id);
            if (bookGenreModels == null)
            {
                return HttpNotFound();
            }
            return View(bookGenreModels);
        }

        // POST: BookGenreModels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Genre")] BookGenreModels bookGenreModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookGenreModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookGenreModels);
        }

        // GET: BookGenreModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookGenreModels bookGenreModels = db.BookGenreModels.Find(id);
            if (bookGenreModels == null)
            {
                return HttpNotFound();
            }
            return View(bookGenreModels);
        }

        // POST: BookGenreModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookGenreModels bookGenreModels = db.BookGenreModels.Find(id);
            db.BookGenreModels.Remove(bookGenreModels);
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
