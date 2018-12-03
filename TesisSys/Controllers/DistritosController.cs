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
    public class DistritosController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Distritos
        public ActionResult Index()
        {
            var distritos = db.Distritos.Include(d => d.Cantones);
            return View(distritos.ToList());
        }

        // GET: Distritos/Details/5
        public ActionResult Details(int? ProvinciaID, int? CantonID, int? DistritoID)
        {            
            Distritos distritos = db.Distritos.Find(ProvinciaID, CantonID, DistritoID);
            if (distritos == null)
            {
                return HttpNotFound();
            }
            return View(distritos);
        }

        [ChildActionOnly]
        public ActionResult List(int ProvinciaID, int CantonID)
        {
            ViewBag.ProvinciaID = ProvinciaID;
            ViewBag.CantonID = CantonID;

            IEnumerable<Distritos> distritos = db.Distritos.Where(c => c.ProvinciaID == ProvinciaID && c.CantonID == CantonID);

            return PartialView(distritos.AsEnumerable());
        }

        // GET: Distritos/Create
        public ActionResult Create()
        {
            ViewBag.ProvinciaID = new SelectList(db.Cantones, "ProvinciaID", "Nombre");
            return View();
        }

        // POST: Distritos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProvinciaID,CantonID,DistritoID,Nombre,Estado")] Distritos distritos)
        {
            if (ModelState.IsValid)
            {
                db.Distritos.Add(distritos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinciaID = new SelectList(db.Cantones, "ProvinciaID", "Nombre", distritos.ProvinciaID);
            return View(distritos);
        }

        // GET: Distritos/Edit/5
        public ActionResult Edit(int? ProvinciaID, int? CantonID, int? DistritoID)
        {            
            Distritos distritos = db.Distritos.Find(ProvinciaID, CantonID, DistritoID);
            if (distritos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinciaID = new SelectList(db.Cantones, "ProvinciaID", "Nombre", distritos.ProvinciaID);
            return View(distritos);
        }

        // POST: Distritos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProvinciaID,CantonID,DistritoID,Nombre,Estado")] Distritos distritos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distritos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinciaID = new SelectList(db.Cantones, "ProvinciaID", "Nombre", distritos.ProvinciaID);
            return View(distritos);
        }

        // GET: Distritos/Delete/5
        public ActionResult Delete(int? ProvinciaID, int? CantonID, int? DistritoID)
        {
            
            Distritos distritos = db.Distritos.Find(ProvinciaID, CantonID, DistritoID);
            if (distritos == null)
            {
                return HttpNotFound();
            }
            return View(distritos);
        }

        // POST: Distritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ProvinciaID, int CantonID, int DistritoID)
        {
            Distritos distritos = db.Distritos.Find(ProvinciaID, CantonID, DistritoID);
            db.Distritos.Remove(distritos);
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
