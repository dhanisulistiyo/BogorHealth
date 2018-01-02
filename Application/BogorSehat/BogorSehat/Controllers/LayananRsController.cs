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
    public class LayananRsController : ApiController
    {
        private BogorHealthEntities db = new BogorHealthEntities();

        // GET: api/LayananRs
        public IQueryable<LayananR> GetLayananRS()
        {
            return db.LayananRS;
        }

        // GET: api/LayananRs/5
        [ResponseType(typeof(LayananRS))]
        public IHttpActionResult GetLayananR(string id)
        {
            string baseUrl = Url.Request.RequestUri.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped);

            List<LayananRS> rs = null;
            rs = db.LayananRS.Where(b => b.IdRS == id).Select(m => new LayananRS{
                IdLayanan = m.IdLayanan,
                IdRS= m.IdRS,
                IdLayananRS = m.IdLayananRS,
                Layanan = db.JenisLayanans.Where(st => st.IdLayanan == m.IdLayanan).Select(st => new Layanans
                {
                    IdLayanan = st.IdLayanan,
                    ImageUrl = st.ImageUrl,
                    JenisLayanan = st.JenisLayanan1,
                    Deskripsi = st.Deskripsi
                }).FirstOrDefault()
            }).ToList();
            if (rs.Count == 0)
            {
                var responseMessage = "Tidak ada layanan di rumah sakit ini";
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new Exception(responseMessage)));
            }


            return Ok(rs);
        }

        // PUT: api/LayananRs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLayananR(string id, LayananR layananR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != layananR.IdLayananRS)
            {
                return BadRequest();
            }

            db.Entry(layananR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LayananRExists(id))
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

        // POST: api/LayananRs
        [ResponseType(typeof(LayananR))]
        public IHttpActionResult PostLayananR(LayananR layananR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LayananRS.Add(layananR);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LayananRExists(layananR.IdLayananRS))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = layananR.IdLayananRS }, layananR);
        }

        // DELETE: api/LayananRs/5
        [ResponseType(typeof(LayananR))]
        public IHttpActionResult DeleteLayananR(string id)
        {
            LayananR layananR = db.LayananRS.Find(id);
            if (layananR == null)
            {
                return NotFound();
            }

            db.LayananRS.Remove(layananR);
            db.SaveChanges();

            return Ok(layananR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LayananRExists(string id)
        {
            return db.LayananRS.Count(e => e.IdLayananRS == id) > 0;
        }
    }
}