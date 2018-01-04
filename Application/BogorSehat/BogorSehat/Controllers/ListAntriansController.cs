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
    public class ListAntriansController : Controller
    {
        private BogorHealthEntities db = new BogorHealthEntities();

        // GET: ListAntrians
        public ActionResult Index()
        {
            var antrians = db.Antrians.Include(a => a.LayananR).Include(a => a.Pasien);
            return View(antrians.ToList());
        }

        // GET: ListAntrians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Antrian antrian = db.Antrians.Find(id);
            if (antrian == null)
            {
                return HttpNotFound();
            }
            return View(antrian);
        }

        // GET: ListAntrians/Create
        public ActionResult Create()
        {
            ViewBag.IdLayananRS = new SelectList(db.LayananRS, "IdLayananRS", "IdLayanan");
            ViewBag.NIK = new SelectList(db.Pasiens, "NIK", "Nama");
            return View();
        }

        // POST: ListAntrians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NIK,NoAntrian,TanggalDaftar,IdLayananRS")] Antrian antrian)
        {
            if (ModelState.IsValid)
            {
                db.Antrians.Add(antrian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLayananRS = new SelectList(db.LayananRS, "IdLayananRS", "IdLayanan", antrian.IdLayananRS);
            ViewBag.NIK = new SelectList(db.Pasiens, "NIK", "Nama", antrian.NIK);
            return View(antrian);
        }

        // GET: ListAntrians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Antrian antrian = db.Antrians.Find(id);
            if (antrian == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLayananRS = new SelectList(db.LayananRS, "IdLayananRS", "IdLayanan", antrian.IdLayananRS);
            ViewBag.NIK = new SelectList(db.Pasiens, "NIK", "Nama", antrian.NIK);
            return View(antrian);
        }

        // POST: ListAntrians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NIK,NoAntrian,TanggalDaftar,IdLayananRS")] Antrian antrian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(antrian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLayananRS = new SelectList(db.LayananRS, "IdLayananRS", "IdLayanan", antrian.IdLayananRS);
            ViewBag.NIK = new SelectList(db.Pasiens, "NIK", "Nama", antrian.NIK);
            return View(antrian);
        }

        // GET: ListAntrians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Antrian antrian = db.Antrians.Find(id);
            if (antrian == null)
            {
                return HttpNotFound();
            }
            return View(antrian);
        }

        // POST: ListAntrians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Antrian antrian = db.Antrians.Find(id);
            db.Antrians.Remove(antrian);
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
