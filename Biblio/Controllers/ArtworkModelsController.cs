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
    public class ArtworkModelsController : Controller
    {
        private ArtworkDBContext db = new ArtworkDBContext();

        // GET: ArtworkModels
        public ActionResult Index()
        {
            return View(db.ArtworkModels.ToList());
        }

        // GET: ArtworkModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtworkModels artworkModels = db.ArtworkModels.Find(id);
            if (artworkModels == null)
            {
                return HttpNotFound();
            }
            return View(artworkModels);
        }

        // GET: ArtworkModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtworkModels/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,PublicationDate")] ArtworkModels artworkModels)
        {
            if (ModelState.IsValid)
            {
                db.ArtworkModels.Add(artworkModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artworkModels);
        }

        // GET: ArtworkModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtworkModels artworkModels = db.ArtworkModels.Find(id);
            if (artworkModels == null)
            {
                return HttpNotFound();
            }
            return View(artworkModels);
        }

        // POST: ArtworkModels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,PublicationDate")] ArtworkModels artworkModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artworkModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artworkModels);
        }

        // GET: ArtworkModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtworkModels artworkModels = db.ArtworkModels.Find(id);
            if (artworkModels == null)
            {
                return HttpNotFound();
            }
            return View(artworkModels);
        }

        // POST: ArtworkModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtworkModels artworkModels = db.ArtworkModels.Find(id);
            db.ArtworkModels.Remove(artworkModels);
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
