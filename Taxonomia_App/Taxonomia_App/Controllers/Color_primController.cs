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
    public class Color_primController : Controller
    {
        private TaxonomiaEntities db = new TaxonomiaEntities();

        // GET: Color_prim
        public ActionResult Index()
        {
            return View(db.Color_prim.ToList());
        }

        // GET: Color_prim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color_prim color_prim = db.Color_prim.Find(id);
            if (color_prim == null)
            {
                return HttpNotFound();
            }
            return View(color_prim);
        }

        // GET: Color_prim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Color_prim/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Color_prim1")] Color_prim color_prim)
        {
            if (ModelState.IsValid)
            {
                db.Color_prim.Add(color_prim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(color_prim);
        }

        // GET: Color_prim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color_prim color_prim = db.Color_prim.Find(id);
            if (color_prim == null)
            {
                return HttpNotFound();
            }
            return View(color_prim);
        }

        // POST: Color_prim/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Color_prim1")] Color_prim color_prim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(color_prim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(color_prim);
        }

        // GET: Color_prim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color_prim color_prim = db.Color_prim.Find(id);
            if (color_prim == null)
            {
                return HttpNotFound();
            }
            return View(color_prim);
        }

        // POST: Color_prim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Color_prim color_prim = db.Color_prim.Find(id);
            db.Color_prim.Remove(color_prim);
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
