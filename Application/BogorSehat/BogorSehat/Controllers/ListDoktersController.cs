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
    public class ListDoktersController : Controller
    {
        private BogorHealthEntities db = new BogorHealthEntities();

        // GET: ListDokters
        public ActionResult Index()
        {
            var dokters = db.Dokters.Include(d => d.Agama1).Include(d => d.Spesiali);
            return View(dokters.ToList());
        }

        // GET: ListDokters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokter dokter = db.Dokters.Find(id);
            if (dokter == null)
            {
                return HttpNotFound();
            }
            return View(dokter);
        }

        // GET: ListDokters/Create
        public ActionResult Create()
        {
            ViewBag.Agama = new SelectList(db.Agamas, "Id", "Nama");
            ViewBag.IdSpesialis = new SelectList(db.Spesialis, "IdSpesialis", "NamaSpesialis");
            return View();
        }

        // POST: ListDokters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NPA,Nama,JenisKelamin,TanggalLahir,KotaLahir,Email,Alamat,Password,IdSpesialis,Agama,ImageUrl")] Dokter dokter)
        {
            if (ModelState.IsValid)
            {
                db.Dokters.Add(dokter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Agama = new SelectList(db.Agamas, "Id", "Nama", dokter.Agama);
            ViewBag.IdSpesialis = new SelectList(db.Spesialis, "IdSpesialis", "NamaSpesialis", dokter.IdSpesialis);
            return View(dokter);
        }

        // GET: ListDokters/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokter dokter = db.Dokters.Find(id);
            if (dokter == null)
            {
                return HttpNotFound();
            }
            ViewBag.Agama = new SelectList(db.Agamas, "Id", "Nama", dokter.Agama);
            ViewBag.IdSpesialis = new SelectList(db.Spesialis, "IdSpesialis", "NamaSpesialis", dokter.IdSpesialis);
            return View(dokter);
        }

        // POST: ListDokters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NPA,Nama,JenisKelamin,TanggalLahir,KotaLahir,Email,Alamat,Password,IdSpesialis,Agama,ImageUrl")] Dokter dokter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dokter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Agama = new SelectList(db.Agamas, "Id", "Nama", dokter.Agama);
            ViewBag.IdSpesialis = new SelectList(db.Spesialis, "IdSpesialis", "NamaSpesialis", dokter.IdSpesialis);
            return View(dokter);
        }

        // GET: ListDokters/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokter dokter = db.Dokters.Find(id);
            if (dokter == null)
            {
                return HttpNotFound();
            }
            return View(dokter);
        }

        // POST: ListDokters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Dokter dokter = db.Dokters.Find(id);
            db.Dokters.Remove(dokter);
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
