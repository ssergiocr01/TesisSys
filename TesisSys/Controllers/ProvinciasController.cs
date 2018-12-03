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
    public class ProvinciasController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Provincias
        public ActionResult Index()
        {
            return View(db.Provincias.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincias provincias = db.Provincias.Where(p => p.ProvinciaID == id).Include(p => p.Cantones).Single();
            if (provincias == null)
            {
                return HttpNotFound();
            }
            return View(provincias);
        }

        // GET: Provincias/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Provincias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProvinciaID,Nombre,Estado")] Provincias provincias)
        {
            if (ModelState.IsValid)
            {
                db.Provincias.Add(provincias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView("Create", provincias);
        }

        // GET: Provincias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincias provincias = db.Provincias.Find(id);
            if (provincias == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", provincias);
        }

        // POST: Provincias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProvinciaID,Nombre,Estado")] Provincias provincias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provincias).State = EntityState.Modified;
                db.SaveChanges();
                string url = Url.Action("Index", "Provincias");
                return Json(new { success = true, url = url });
                //return RedirectToAction("Index");
            }
            return PartialView("Edit", provincias);
        }

        // GET: Provincias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincias provincias = db.Provincias.Find(id);
            if (provincias == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", provincias);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provincias provincias = db.Provincias.Find(id);
            db.Provincias.Remove(provincias);
            db.SaveChanges();

            string url = Url.Action("Index", "Provincias");
            return Json(new { success = true, url = url });
            //return RedirectToAction("Index");
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
