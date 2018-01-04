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
    public class ListRSController : Controller
    {
        private BogorHealthEntities db = new BogorHealthEntities();

        // GET: ListRS
        public ActionResult Index()
        {
            var rumahSakits = db.RumahSakits.Include(r => r.Admin);
            return View(rumahSakits.ToList());
        }

        // GET: ListRS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RumahSakit rumahSakit = db.RumahSakits.Find(id);
            if (rumahSakit == null)
            {
                return HttpNotFound();
            }
            return View(rumahSakit);
        }

        // GET: ListRS/Create
        public ActionResult Create()
        {
            ViewBag.IdAdmin = new SelectList(db.Admins, "NIP", "Nama");
            return View();
        }

        // POST: ListRS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRS,NamaRS,JenisRS,KelasRS,Deskripsi,Visi,Misi,Direktur,Alamat,Penyelenggara,Website,Kota,KodePos,Telephone,Fax,ImageUrl,IdAdmin")] RumahSakit rumahSakit)
        {
            if (ModelState.IsValid)
            {
                db.RumahSakits.Add(rumahSakit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAdmin = new SelectList(db.Admins, "NIP", "Nama", rumahSakit.IdAdmin);
            return View(rumahSakit);
        }

        // GET: ListRS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RumahSakit rumahSakit = db.RumahSakits.Find(id);
            if (rumahSakit == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAdmin = new SelectList(db.Admins, "NIP", "Nama", rumahSakit.IdAdmin);
            return View(rumahSakit);
        }

        // POST: ListRS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRS,NamaRS,JenisRS,KelasRS,Deskripsi,Visi,Misi,Direktur,Alamat,Penyelenggara,Website,Kota,KodePos,Telephone,Fax,ImageUrl,IdAdmin")] RumahSakit rumahSakit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rumahSakit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAdmin = new SelectList(db.Admins, "NIP", "Nama", rumahSakit.IdAdmin);
            return View(rumahSakit);
        }

        // GET: ListRS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RumahSakit rumahSakit = db.RumahSakits.Find(id);
            if (rumahSakit == null)
            {
                return HttpNotFound();
            }
            return View(rumahSakit);
        }

        // POST: ListRS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RumahSakit rumahSakit = db.RumahSakits.Find(id);
            db.RumahSakits.Remove(rumahSakit);
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
