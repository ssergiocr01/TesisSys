using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesisSys.Models;

namespace TesisSys.Controllers
{
    public class CantonesController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Cantones
        public ActionResult Index()
        {
            var cantones = db.Cantones.Include(c => c.Provincias);
            return View(cantones.ToList());
        }

        // GET: Cantones/Details/5
        public ActionResult Details(int? ProvinciaID, int? CantonID)
        {
            Cantones cantones = db.Cantones.Find(ProvinciaID, CantonID);

            if (cantones == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (cantones == null)
            {
                return HttpNotFound();
            }
            return View(cantones);
        }

        // GET: Cantones/Create
        public ActionResult Create()
        {
            ViewBag.ProvinciaID = new SelectList(db.Provincias, "ProvinciaID", "Nombre");
            return PartialView();
        }

        // POST: Cantones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProvinciaID,CantonID,Nombre,Estado")] Cantones cantones)
        {
            if (ModelState.IsValid)
            {
                db.Cantones.Add(cantones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinciaID = new SelectList(db.Provincias, "ProvinciaID", "Nombre", cantones.ProvinciaID);
            return View(cantones);
        }

        // GET: Cantones/Edit/5
        public ActionResult Edit(int? ProvinciaID, int? CantonID)
        {
            Cantones cantones = db.Cantones.Find(ProvinciaID, CantonID);            
            
            if (cantones == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinciaID = new SelectList(db.Provincias, "ProvinciaID", "Nombre", cantones.ProvinciaID);
            return View(cantones);
        }

        // POST: Cantones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProvinciaID,CantonID,Nombre,Estado")] Cantones cantones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cantones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinciaID = new SelectList(db.Provincias, "ProvinciaID", "Nombre", cantones.ProvinciaID);
            return View(cantones);
        }

        // GET: Cantones/Delete/5
        public ActionResult Delete(int? ProvinciaID, int? CantonID)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Cantones cantones = db.Cantones.Find(ProvinciaID, CantonID);

            if (cantones == null)
            {
                return HttpNotFound();
            }
            return View(cantones);
        }

        // POST: Cantones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ProvinciaID, int CantonID)
        {
            Cantones cantones = db.Cantones.Find(ProvinciaID, CantonID);
            db.Cantones.Remove(cantones);
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
