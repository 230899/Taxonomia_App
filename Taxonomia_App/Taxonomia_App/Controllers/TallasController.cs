using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Taxonomia_App.Models;

namespace Taxonomia_App.Controllers
{
    public class TallasController : Controller
    {
        private TaxonomiaEntities db = new TaxonomiaEntities();

        // GET: Tallas
        public ActionResult Index()
        {
            return View(db.Talla.ToList());
        }

        // GET: Tallas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talla talla = db.Talla.Find(id);
            if (talla == null)
            {
                return HttpNotFound();
            }
            return View(talla);
        }

        // GET: Tallas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tallas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Talla1,Num_Talla")] Talla talla)
        {
            if (ModelState.IsValid)
            {
                db.Talla.Add(talla);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talla);
        }

        // GET: Tallas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talla talla = db.Talla.Find(id);
            if (talla == null)
            {
                return HttpNotFound();
            }
            return View(talla);
        }

        // POST: Tallas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Talla1,Num_Talla")] Talla talla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talla);
        }

        // GET: Tallas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talla talla = db.Talla.Find(id);
            if (talla == null)
            {
                return HttpNotFound();
            }
            return View(talla);
        }

        // POST: Tallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Talla talla = db.Talla.Find(id);
            db.Talla.Remove(talla);
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
