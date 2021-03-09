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
    public class SKUsController : Controller
    {
        private TaxonomiaEntities db = new TaxonomiaEntities();

        // GET: SKUs
        public ActionResult Index()
        {
            return View(db.SKU.ToList());
        }

        // GET: SKUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SKU sKU = db.SKU.Find(id);
            if (sKU == null)
            {
                return HttpNotFound();
            }
            return View(sKU);
        }

        // GET: SKUs/Create
        public ActionResult Create()
        {
            ViewBag.coloresPrimarios = db.Color_prim.ToList();
            ViewBag.coloresSec = db.Color_sec.ToList();
            ViewBag.divisiones = db.Division.ToList();
            ViewBag.familias = db.Familia.ToList();
            ViewBag.generos = db.Genero.ToList();
            ViewBag.materiales = db.Material.ToList();
            ViewBag.modelos = db.Modelo.ToList();
            ViewBag.tallas = db.Talla.ToList();
            return View();
        }

        

        // POST: SKUs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Codigo")] SKU sKU)
        {
           
            if (ModelState.IsValid)
            {
                db.SKU.Add(sKU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sKU);
        }

        // GET: SKUs/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.coloresPrimarios = db.Color_prim.ToList();
            ViewBag.coloresSec = db.Color_sec.ToList();
            ViewBag.divisiones = db.Division.ToList();
            ViewBag.familias = db.Familia.ToList();
            ViewBag.generos = db.Genero.ToList();
            ViewBag.materiales = db.Material.ToList();
            ViewBag.modelos = db.Modelo.ToList();
            ViewBag.tallas = db.Talla.ToList();
            ViewBag.sku = db.SKU.ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SKU sKU = db.SKU.Find(id);
            if (sKU == null)
            {
                return HttpNotFound();
            }
            return View(sKU);
        }

        // POST: SKUs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Codigo")] SKU sKU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sKU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sKU);
        }


        // GET: SKUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SKU sKU = db.SKU.Find(id);
            if (sKU == null)
            {
                return HttpNotFound();
            }
            return View(sKU);
        }

        // POST: SKUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SKU sKU = db.SKU.Find(id);
            db.SKU.Remove(sKU);
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
