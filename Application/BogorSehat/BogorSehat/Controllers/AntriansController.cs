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
using System.Data.Entity.Core.Objects;
using BogorSehat.Models;

namespace BogorSehat.Controllers
{
    public class AntriansController : ApiController
    {
        private BogorHealthEntities db = new BogorHealthEntities();

        // GET: api/Antrians
        [ResponseType(typeof(Antrian))]
        public IHttpActionResult GetNumAntrian(String nik, String idlayanan)
        {
            Antrian ar = new Antrian();
            var user = db.Pasiens.Find(nik);
            if (user == null)
            {
                var responseMessage = "Akun ini tidak terdaftar silahkan  .";
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new Exception(responseMessage)));
            }
            var date = DateTime.Now;
            var antrianByDate = db.Antrians.Where(b => EntityFunctions.TruncateTime(b.TanggalDaftar) == date.Date).ToList();

            if (antrianByDate.Count > 0)
            {
                var check = false;
                var noAntrian = 0;
                for (var i = 0; i < antrianByDate.Count; i++)
                {
                    if (antrianByDate[i].NIK == nik)
                        check = true;
                    if (antrianByDate[i].IdLayananRS == idlayanan)
                        noAntrian = antrianByDate[i].NoAntrian;
                }

                if (check == true)
                {
                    var responseMessage = "Akun ini sudah mendaftar antrian pada hari ini. Silahkan coba hari selanjutnya.";
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new Exception(responseMessage)));
                } else
                {
                    ar.NIK = nik;
                    ar.NoAntrian = noAntrian + 1;
                    ar.IdLayananRS = idlayanan;
                    ar.TanggalDaftar = date;
                    db.Antrians.Add(ar);
                    db.SaveChanges();
                }
            } else
            {
                ar.NIK = nik;
                ar.NoAntrian = 1;
                ar.IdLayananRS = idlayanan;
                ar.TanggalDaftar = date;
                db.Antrians.Add(ar);
                db.SaveChanges();
            }

            var res = new Antrians();
            res.NIK = ar.NIK;
            res.NoAntrian = ar.NoAntrian;
            res.TanggalDaftar = ar.TanggalDaftar;
            var lay = db.LayananRS.Where(d => d.IdLayananRS == ar.IdLayananRS).FirstOrDefault();
            res.Pasien = db.Pasiens.Where(d => d.NIK == nik).Select(b => new Pasiens
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
            }).FirstOrDefault();

            res.RumahSakit = db.RumahSakits.Where(d => d.IdRS == lay.IdRS).Select(b => new RumahSakits
            {
                IdRS = b.IdRS,
                Deskripsi = b.Deskripsi,
                Direktur = b.Direktur,
                Fax = b.Fax,
                Alamat = b.Alamat,
                JenisRS = b.JenisRS,
                KelasRS = b.KelasRS,
                ImageUrl = b.ImageUrl,
                KodePos = b.KodePos,
                Kota = b.Kota,
                Misi = b.Misi,
                NamaRS = b.NamaRS,
                Penyelenggara = b.Penyelenggara,
                Telephone = b.Telephone,
                Visi = b.Visi,
                Website = b.Website
            }).FirstOrDefault();
            

            return Ok(res);
        }

        // GET: api/Antrians/5
        [ResponseType(typeof(Antrian))]
        public IHttpActionResult GetAntrian(string id)
        {
            Antrian antrian = db.Antrians.Find(id);
            if (antrian == null)
            {
                return NotFound();
            }

            return Ok(antrian);
        }

        // PUT: api/Antrians/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAntrian(string id, Antrian antrian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != antrian.NIK)
            {
                return BadRequest();
            }

            db.Entry(antrian).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AntrianExists(id))
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

        // POST: api/Antrians
        [ResponseType(typeof(Antrian))]
        public IHttpActionResult PostAntrian(Antrian antrian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Antrians.Add(antrian);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AntrianExists(antrian.NIK))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = antrian.NIK }, antrian);
        }

        // DELETE: api/Antrians/5
        [ResponseType(typeof(Antrian))]
        public IHttpActionResult DeleteAntrian(string id)
        {
            Antrian antrian = db.Antrians.Find(id);
            if (antrian == null)
            {
                return NotFound();
            }

            db.Antrians.Remove(antrian);
            db.SaveChanges();

            return Ok(antrian);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AntrianExists(string id)
        {
            return db.Antrians.Count(e => e.NIK == id) > 0;
        }
    }
}