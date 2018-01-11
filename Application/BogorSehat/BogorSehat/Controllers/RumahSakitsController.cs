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
    public class RumahSakitsController : ApiController
    {
        private BogorHealthEntities db = new BogorHealthEntities();
       

        // GET: api/RumahSakits
        public IHttpActionResult GetRumahSakits()
        {
            string url = Url.Request.RequestUri.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped);
            string baseUrl = url + "/Content/img/";

            //return db.RumahSakits;
            List<RumahSakits> rs = null;
            rs = db.RumahSakits.Select(b => new RumahSakits
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
            }).ToList();

            return Ok(rs);
        }

        // GET: api/RumahSakits/5
        [ResponseType(typeof(RumahSakit))]
        public IHttpActionResult GetRumahSakit(string id)
        {
            RumahSakit rumahSakit = db.RumahSakits.Find(id);
            if (rumahSakit == null)
            {
                return NotFound();
            }

            return Ok(rumahSakit);
        }

        // PUT: api/RumahSakits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRumahSakit(string id, RumahSakit rumahSakit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rumahSakit.IdRS)
            {
                return BadRequest();
            }

            db.Entry(rumahSakit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RumahSakitExists(id))
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

        // POST: api/RumahSakits
        [ResponseType(typeof(RumahSakit))]
        public IHttpActionResult PostRumahSakit(RumahSakit rumahSakit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RumahSakits.Add(rumahSakit);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RumahSakitExists(rumahSakit.IdRS))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rumahSakit.IdRS }, rumahSakit);
        }

        // DELETE: api/RumahSakits/5
        [ResponseType(typeof(RumahSakit))]
        public IHttpActionResult DeleteRumahSakit(string id)
        {
            RumahSakit rumahSakit = db.RumahSakits.Find(id);
            if (rumahSakit == null)
            {
                return NotFound();
            }

            db.RumahSakits.Remove(rumahSakit);
            db.SaveChanges();

            return Ok(rumahSakit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RumahSakitExists(string id)
        {
            return db.RumahSakits.Count(e => e.IdRS == id) > 0;
        }

        private string imgUrl(string img)
        {
            string url = Url.Request.RequestUri.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped);
            string baseUrl = url + "/Content/img/";

            if (img == null)
            {
                return null;
            }else
            {
                return baseUrl+img;

            }

           
        }
    }
}