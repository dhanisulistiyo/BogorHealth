﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BogorSehat.Models.Entities;
using BogorSehat.Models;

namespace BogorSehat.Controllers
{
    public class PasiensController : ApiController
    {
        private BogorHealthEntities db = new BogorHealthEntities();

        // GET: api/Pasiens
        public IQueryable<Pasiens> GetPasiens()
        {
            List<Pasiens> pasien = null;
            pasien = db.Pasiens.Select(b => new Pasiens
                                    {
                                        NIK = b.NIK,
                                        Nama = b.Nama,
                                        TanggalLahir = b.TanggalLahir,
                                        Alamat = b.Alamat,
                                        KotaLahir = b.KotaLahir,
                                        Email = b.Email,
                                        JenisKelamin = b.JenisKelamin,
                                        Pekerjaan = b.Pekerjaan,
                                        StatusPernikahan = b.StatusPernikahan,
                                        ImageUrl = b.ImageUrl,
                                        Agama = b.Agama1.Nama
                                    }).ToList();
            return pasien.AsQueryable();
        }

        // GET: api/Pasiens/5
        [ResponseType(typeof(Pasien))]
        public IHttpActionResult GetPasien(string id)
        {
            Pasien pasien = db.Pasiens.Find(id);
            if (pasien == null)
            {
                return NotFound();
            }

            return Ok(pasien);
        }

        // PUT: api/Pasiens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPasien(string id, Pasien pasien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pasien.NIK)
            {
                return BadRequest();
            }

            db.Entry(pasien).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasienExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pasiens
        [ResponseType(typeof(Pasien))]
        public IHttpActionResult PostPasien(Pasien pasien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pasiens.Add(pasien);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PasienExists(pasien.NIK))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pasien.NIK }, pasien);
        }

        // DELETE: api/Pasiens/5
        [ResponseType(typeof(Pasien))]
        public IHttpActionResult DeletePasien(string id)
        {
            Pasien pasien = db.Pasiens.Find(id);
            if (pasien == null)
            {
                return NotFound();
            }

            db.Pasiens.Remove(pasien);
            db.SaveChanges();

            return Ok(pasien);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PasienExists(string id)
        {
            return db.Pasiens.Count(e => e.NIK == id) > 0;
        }
    }
}