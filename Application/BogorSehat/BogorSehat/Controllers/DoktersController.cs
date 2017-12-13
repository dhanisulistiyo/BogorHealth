using System;
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
    public class DoktersController : ApiController
    {
        private BogorHealthEntities db = new BogorHealthEntities();

        // GET: api/Dokters
        public IQueryable<Dokters> GetDokters()
        {
            //return db.Dokters;
            List<Dokters> dok = null;
            dok = db.Dokters.Select(b => new Dokters
            {
                NPA = b.NPA,
                Nama = b.Nama,
                TanggalLahir = b.TanggalLahir,
                Alamat = b.Alamat,
                KotaLahir = b.KotaLahir,
                Email = b.Email,
                JenisKelamin = b.JenisKelamin,
                ImageUrl = b.ImageUrl,
                Agama = b.Agama1.Nama,
                Spesiali = db.Spesialis.Where(st => st.IdSpesialis == b.IdSpesialis).Select(st => new Spesialis
                {
                    IdSpesialis = st.IdSpesialis,
                    NamaSpesialis = st.NamaSpesialis,
                    Gelar = st.Gelar,
                    Deskripsi = st.Deskripsi
                }).FirstOrDefault()
        }).ToList();
            return dok.AsQueryable();
        }

        // GET: api/Dokters/5
        [ResponseType(typeof(Dokter))]
        public IHttpActionResult GetDokter(string id)
        {
            Dokter dokter = db.Dokters.Find(id);
            if (dokter == null)
            {
                return NotFound();
            }
            Dokters dok = new Dokters();
            Spesialis sp = new Spesialis();
            dok.NPA = dokter.NPA;
            dok.Nama = dokter.Nama;
            dok.TanggalLahir = dokter.TanggalLahir;
            dok.Alamat = dokter.Alamat;
            dok.KotaLahir = dokter.KotaLahir;
            dok.Email = dokter.Email;
            dok.JenisKelamin = dokter.JenisKelamin;
            dok.ImageUrl = dokter.ImageUrl;
            dok.Agama = dokter.Agama1.Nama;
            sp.IdSpesialis = dokter.Spesiali.IdSpesialis;
            sp.NamaSpesialis = dokter.Spesiali.NamaSpesialis;
            sp.Gelar = dokter.Spesiali.Gelar;
            sp.Deskripsi = dokter.Spesiali.Deskripsi;
            dok.Spesiali = sp;
            return Ok(dok);
        }

        // PUT: api/Dokters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDokter(string id, Dokter dokter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dokter.NPA)
            {
                return BadRequest();
            }

            db.Entry(dokter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DokterExists(id))
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

        // DELETE: api/Dokters/5
        [ResponseType(typeof(Dokter))]
        public IHttpActionResult DeleteDokter(string id)
        {
            Dokter dokter = db.Dokters.Find(id);
            if (dokter == null)
            {
                return NotFound();
            }

            db.Dokters.Remove(dokter);
            db.SaveChanges();

            return Ok(dokter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool DokterExists(string id)
        {
            return db.Dokters.Count(e => e.NPA == id) > 0;
        }
    }
}