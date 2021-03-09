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
    public class Color_secController : Controller
    {
        private TaxonomiaEntities db = new TaxonomiaEntities();

        // GET: Color_sec
        public ActionResult Index()
        {
            return View(db.Color_sec.ToList());
        }

        // GET: Color_sec/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color_sec color_sec = db.Color_sec.Find(id);
            if (color_sec == null)
            {
                return HttpNotFound();
            }
            return View(color_sec);
        }

        // GET: Color_sec/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Color_sec/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Color_sec1")] Color_sec color_sec)
        {
            if (ModelState.IsValid)
            {
                db.Color_sec.Add(color_sec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(color_sec);
        }

        // GET: Color_sec/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color_sec color_sec = db.Color_sec.Find(id);
            if (color_sec == null)
            {
                return HttpNotFound();
            }
            return View(color_sec);
        }

        // POST: Color_sec/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Color_sec1")] Color_sec color_sec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(color_sec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(color_sec);
        }

        // GET: Color_sec/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color_sec color_sec = db.Color_sec.Find(id);
            if (color_sec == null)
            {
                return HttpNotFound();
            }
            return View(color_sec);
        }

        // POST: Color_sec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Color_sec color_sec = db.Color_sec.Find(id);
            db.Color_sec.Remove(color_sec);
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
