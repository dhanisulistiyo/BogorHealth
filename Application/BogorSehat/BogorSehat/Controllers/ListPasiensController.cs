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
    public class ListPasiensController : Controller
    {
        private BogorHealthEntities db = new BogorHealthEntities();

        // GET: ListPasiens
        public ActionResult Index()
        {
            var pasiens = db.Pasiens.Include(p => p.Agama1);
            return View(pasiens.ToList());
        }

        // GET: ListPasiens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasien pasien = db.Pasiens.Find(id);
            if (pasien == null)
            {
                return HttpNotFound();
            }
            return View(pasien);
        }

        // GET: ListPasiens/Create
        public ActionResult Create()
        {
            ViewBag.Agama = new SelectList(db.Agamas, "Id", "Nama");
            return View();
        }

        // POST: ListPasiens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NIK,Nama,Alamat,TanggalLahir,KotaLahir,Email,JenisKelamin,Pekerjaan,StatusPernikahan,Agama,Password,ImageUrl")] Pasien pasien)
        {
            if (ModelState.IsValid)
            {
                db.Pasiens.Add(pasien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Agama = new SelectList(db.Agamas, "Id", "Nama", pasien.Agama);
            return View(pasien);
        }

        // GET: ListPasiens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasien pasien = db.Pasiens.Find(id);
            if (pasien == null)
            {
                return HttpNotFound();
            }
            ViewBag.Agama = new SelectList(db.Agamas, "Id", "Nama", pasien.Agama);
            return View(pasien);
        }

        // POST: ListPasiens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NIK,Nama,Alamat,TanggalLahir,KotaLahir,Email,JenisKelamin,Pekerjaan,StatusPernikahan,Agama,Password,ImageUrl")] Pasien pasien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Agama = new SelectList(db.Agamas, "Id", "Nama", pasien.Agama);
            return View(pasien);
        }

        // GET: ListPasiens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasien pasien = db.Pasiens.Find(id);
            if (pasien == null)
            {
                return HttpNotFound();
            }
            return View(pasien);
        }

        // POST: ListPasiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Pasien pasien = db.Pasiens.Find(id);
            db.Pasiens.Remove(pasien);
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
