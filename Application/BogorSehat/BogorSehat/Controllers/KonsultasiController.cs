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
    public class KonsultasiController : Controller
    {
        private BogorHealthEntities db = new BogorHealthEntities();

        // GET: Konsultasi
        public ActionResult Index()
        {
            var konsultasis = db.Konsultasis.Include(k => k.Dokter).Include(k => k.Pasien);
            return View(konsultasis.ToList());
        }

        // GET: Konsultasi/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konsultasi konsultasi = db.Konsultasis.Find(id);
            if (konsultasi == null)
            {
                return HttpNotFound();
            }
            return View(konsultasi);
        }

        // GET: Konsultasi/Create
        public ActionResult Create()
        {
            ViewBag.NPA = new SelectList(db.Dokters, "NPA", "Nama");
            ViewBag.NIK = new SelectList(db.Pasiens, "NIK", "Nama");
            return View();
        }

        // POST: Konsultasi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NIK,NPA,Chat,DateTime")] Konsultasi konsultasi)
        {
            if (ModelState.IsValid)
            {
                db.Konsultasis.Add(konsultasi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NPA = new SelectList(db.Dokters, "NPA", "Nama", konsultasi.NPA);
            ViewBag.NIK = new SelectList(db.Pasiens, "NIK", "Nama", konsultasi.NIK);
            return View(konsultasi);
        }

        // GET: Konsultasi/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konsultasi konsultasi = db.Konsultasis.Find(id);
            if (konsultasi == null)
            {
                return HttpNotFound();
            }
            ViewBag.NPA = new SelectList(db.Dokters, "NPA", "Nama", konsultasi.NPA);
            ViewBag.NIK = new SelectList(db.Pasiens, "NIK", "Nama", konsultasi.NIK);
            return View(konsultasi);
        }

        // POST: Konsultasi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NIK,NPA,Chat,DateTime")] Konsultasi konsultasi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(konsultasi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NPA = new SelectList(db.Dokters, "NPA", "Nama", konsultasi.NPA);
            ViewBag.NIK = new SelectList(db.Pasiens, "NIK", "Nama", konsultasi.NIK);
            return View(konsultasi);
        }

        // GET: Konsultasi/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konsultasi konsultasi = db.Konsultasis.Find(id);
            if (konsultasi == null)
            {
                return HttpNotFound();
            }
            return View(konsultasi);
        }

        // POST: Konsultasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Konsultasi konsultasi = db.Konsultasis.Find(id);
            db.Konsultasis.Remove(konsultasi);
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
