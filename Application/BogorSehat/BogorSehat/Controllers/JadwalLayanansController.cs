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
    public class JadwalLayanansController : ApiController
    {
        private BogorHealthEntities db = new BogorHealthEntities();

        // GET: api/JadwalLayanans
        public IQueryable<JadwalLayanan> GetJadwalLayanans()
        {
            return db.JadwalLayanans;
        }

        // GET: api/JadwalLayanans/5
        [ResponseType(typeof(JadwalLayanan))]
        public IHttpActionResult GetJadwalLayanan(string id)
        {
            var jadwalLayanan = db.JadwalLayanans.Where(b => b.IdLayananRS == id);
            if (jadwalLayanan.Count() == 0)
            {
                var responseMessage = "Tidak ada jadwal di layanan ini";
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new Exception(responseMessage)));
            }

            List<JadwalLayanans> jd = jadwalLayanan.Select(b => new JadwalLayanans
            {
                Hari = b.Hari,
                IdJadwal = b.IdJadwal,
                JamMulai = b.JamMulai,
                JamSelesai = b.JamSelesai,
                Dokter = db.Dokters.Where(st => st.NPA == b.IdDokter).Select(st => new Dokters
                {
                    NPA = st.NPA,
                    Nama = st.Nama,
                    JenisKelamin = st.JenisKelamin,
                    Spesiali = db.Spesialis.Where(s => s.IdSpesialis == st.IdSpesialis).Select(s => new Spesialis
                    {
                        IdSpesialis = s.IdSpesialis,
                        NamaSpesialis = s.NamaSpesialis,
                        Gelar = s.Gelar
                    }).FirstOrDefault()
                }).FirstOrDefault()
            }).ToList();

            var jadwal = new List<Jadwal>();
            List<JadwalLayanans> jadwal1 = new List<JadwalLayanans>();
            var jad = new Jadwal();
            for (var i = 0; i < jd.Count; i++)
            {
                if (jd[i].Hari == "Senin")
                {
                    jad.Hari = jd[i].Hari;
                    jadwal1.Add(jd[i]);
                }
            }
           jad.JadwalLayanan = jadwal1;
            if (jad.Hari != null)
                jadwal.Add(jad);

           jadwal1 = new List<JadwalLayanans>();
           jad = new Jadwal();
            for (var i = 0; i < jd.Count; i++)
            {
                if (jd[i].Hari == "Selasa")
                {
                    jad.Hari = jd[i].Hari;
                    jadwal1.Add(jd[i]);
                }
            }
            jad.JadwalLayanan = jadwal1;
            if (jad.Hari != null)
                jadwal.Add(jad);

            jadwal1 = new List<JadwalLayanans>();
            jad = new Jadwal();
            for (var i = 0; i < jd.Count; i++)
            {
                if (jd[i].Hari == "Rabu")
                {
                    jad.Hari = jd[i].Hari;
                    jadwal1.Add(jd[i]);
                }
            }
            jad.JadwalLayanan = jadwal1;
            if (jad.Hari != null)
                jadwal.Add(jad);


            jadwal1 = new List<JadwalLayanans>();
            jad = new Jadwal();
            for (var i = 0; i < jd.Count; i++)
            {
                if (jd[i].Hari == "Kamis")
                {
                    jad.Hari = jd[i].Hari;
                    jadwal1.Add(jd[i]);
                }
            }
            jad.JadwalLayanan = jadwal1;
            if (jad.Hari != null)
                jadwal.Add(jad);


            jadwal1 = new List<JadwalLayanans>();
            jad = new Jadwal();
            for (var i = 0; i < jd.Count; i++)
            {
                if (jd[i].Hari == "Jumat")
                {
                    jad.Hari = jd[i].Hari;
                    jadwal1.Add(jd[i]);
                }
            }
            jad.JadwalLayanan = jadwal1;
            if (jad.Hari != null)
                jadwal.Add(jad);

            jadwal1 = new List<JadwalLayanans>();
            jad = new Jadwal();
            for (var i = 0; i < jd.Count; i++)
            {
                if (jd[i].Hari == "Sabtu")
                {
                    jad.Hari = jd[i].Hari;
                    jadwal1.Add(jd[i]);
                }
            }
            jad.JadwalLayanan = jadwal1;
            if (jad.Hari != null)
                jadwal.Add(jad);

            jadwal1 = new List<JadwalLayanans>();
            jad = new Jadwal();
            for (var i = 0; i < jd.Count; i++)
            {
                if (jd[i].Hari == "Minggu")
                {
                    jad.Hari = jd[i].Hari;
                    jadwal1.Add(jd[i]);
                }
            }
            jad.JadwalLayanan = jadwal1;
            if (jad.Hari != null)
                jadwal.Add(jad);


            return Ok(jadwal);
        }

        // PUT: api/JadwalLayanans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJadwalLayanan(string id, JadwalLayanan jadwalLayanan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jadwalLayanan.IdJadwal)
            {
                return BadRequest();
            }

            db.Entry(jadwalLayanan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JadwalLayananExists(id))
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

        // POST: api/JadwalLayanans
        [ResponseType(typeof(JadwalLayanan))]
        public IHttpActionResult PostJadwalLayanan(JadwalLayanan jadwalLayanan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JadwalLayanans.Add(jadwalLayanan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jadwalLayanan.IdJadwal }, jadwalLayanan);
        }

        // DELETE: api/JadwalLayanans/5
        [ResponseType(typeof(JadwalLayanan))]
        public IHttpActionResult DeleteJadwalLayanan(int id)
        {
            JadwalLayanan jadwalLayanan = db.JadwalLayanans.Find(id);
            if (jadwalLayanan == null)
            {
                return NotFound();
            }

            db.JadwalLayanans.Remove(jadwalLayanan);
            db.SaveChanges();

            return Ok(jadwalLayanan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JadwalLayananExists(string id)
        {
            return db.JadwalLayanans.Count(e => e.IdJadwal == id) > 0;
        }
    }
}