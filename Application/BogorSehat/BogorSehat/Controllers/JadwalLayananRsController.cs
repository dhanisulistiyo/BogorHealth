using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BogorSehat.Models.Entities;

namespace BogorSehat.Controllers
{
    public class JadwalLayananRsController : Controller
    {
        private BogorHealthEntities db = new BogorHealthEntities();

        // GET: JadwalLayananRs
        public ActionResult Index()
        {
            var layananRS = db.LayananRS.Include(l => l.JenisLayanan).Include(l => l.RumahSakit);
            return View(layananRS.ToList());
        }

        // GET: JadwalLayananRs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LayananR layananR = db.LayananRS.Find(id);
            if (layananR == null)
            {
                return HttpNotFound();
            }
            return View(layananR);
        }

        // GET: JadwalLayananRs/Create
        public ActionResult Create()
        {
            ViewBag.IdLayanan = new SelectList(db.JenisLayanans, "IdLayanan", "JenisLayanan1");
            ViewBag.IdRS = new SelectList(db.RumahSakits, "IdRS", "NamaRS");
            return View();
        }

        // POST: JadwalLayananRs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLayanan,IdRS,IdLayananRS")] LayananR layananR)
        {
            if (ModelState.IsValid)
            {
                db.LayananRS.Add(layananR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLayanan = new SelectList(db.JenisLayanans, "IdLayanan", "JenisLayanan1", layananR.IdLayanan);
            ViewBag.IdRS = new SelectList(db.RumahSakits, "IdRS", "NamaRS", layananR.IdRS);
            return View(layananR);
        }

        // GET: JadwalLayananRs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LayananR layananR = db.LayananRS.Find(id);
            if (layananR == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLayanan = new SelectList(db.JenisLayanans, "IdLayanan", "JenisLayanan1", layananR.IdLayanan);
            ViewBag.IdRS = new SelectList(db.RumahSakits, "IdRS", "NamaRS", layananR.IdRS);
            return View(layananR);
        }

        // POST: JadwalLayananRs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLayanan,IdRS,IdLayananRS")] LayananR layananR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(layananR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLayanan = new SelectList(db.JenisLayanans, "IdLayanan", "JenisLayanan1", layananR.IdLayanan);
            ViewBag.IdRS = new SelectList(db.RumahSakits, "IdRS", "NamaRS", layananR.IdRS);
            return View(layananR);
        }

        // GET: JadwalLayananRs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LayananR layananR = db.LayananRS.Find(id);
            if (layananR == null)
            {
                return HttpNotFound();
            }
            return View(layananR);
        }

        // POST: JadwalLayananRs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LayananR layananR = db.LayananRS.Find(id);
            db.LayananRS.Remove(layananR);
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
