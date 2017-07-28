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
    public class AuthorModelsController : Controller
    {
        private AuthorDBContext db = new AuthorDBContext();

        // GET: AuthorModels
        public ActionResult Index()
        {
            return View(db.AuthorModels.ToList());
        }

        // GET: AuthorModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorModels authorModels = db.AuthorModels.Find(id);
            if (authorModels == null)
            {
                return HttpNotFound();
            }
            return View(authorModels);
        }

        // GET: AuthorModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorModels/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Bio,FirstName,LastName,Birthdate,Deathdate")] AuthorModels authorModels)
        {
            if (ModelState.IsValid)
            {
                db.AuthorModels.Add(authorModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorModels);
        }

        // GET: AuthorModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorModels authorModels = db.AuthorModels.Find(id);
            if (authorModels == null)
            {
                return HttpNotFound();
            }
            return View(authorModels);
        }

        // POST: AuthorModels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Bio,FirstName,LastName,Birthdate,Deathdate")] AuthorModels authorModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorModels);
        }

        // GET: AuthorModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorModels authorModels = db.AuthorModels.Find(id);
            if (authorModels == null)
            {
                return HttpNotFound();
            }
            return View(authorModels);
        }

        // POST: AuthorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuthorModels authorModels = db.AuthorModels.Find(id);
            db.AuthorModels.Remove(authorModels);
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
