using BogorSehat.Models;
using BogorSehat.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BogorSehat.Controllers
{

    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class LoginController : ApiController
    {
        private BogorHealthEntities db = new BogorHealthEntities();
        // POST: api/LoginPasien
        [Route("api/LoginPasien")]
        [ResponseType(typeof(Pasiens))]
        public IHttpActionResult LoginPasien(Login login)
        {
            var pasien = db.Pasiens.Where(b => b.NIK == login.Username).FirstOrDefault();

            if (pasien == null)
            {
                //return NotFound();
                var responseMessage = "NIK tidak terdaftar";
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new Exception(responseMessage)));
            }
            else if (pasien != null && pasien.Password != login.Password)
            {
                var responseMessage = "NIK dan Password tidak sesuai";
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new Exception(responseMessage)));
            }
            else
            {
                var p = new User();
                p.UserName = pasien.NIK;
                p.Nama = pasien.Nama;
                p.Email = pasien.Email;
                return Ok(p);
            }

        }

        // POST: api/LoginDokter
        [Route("api/LoginDokter")]
        [ResponseType(typeof(Dokters))]
        public IHttpActionResult LoginDokter(Login login)
        {
            var dokter = db.Dokters.Where(b => b.NPA == login.Username).FirstOrDefault();

            if (dokter == null)
            {
                //return NotFound();
                var responseMessage = "NPA tidak terdaftar";
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new Exception(responseMessage)));
            }
            else if (dokter != null && dokter.Password != login.Password)
            {
                var responseMessage = "NPA dan Password tidak sesuai";
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new Exception(responseMessage)));
            }
            else
            {
                var p = new User();
                p.UserName = dokter.NPA;
                p.Nama = dokter.Nama;
                p.Email = dokter.Email;
                return Ok(p);
            }

        }


        // POST: api/RegisterPasien
        [Route("api/RegisterPasien")]
        [ResponseType(typeof(Pasiens))]
        public IHttpActionResult PostPasien(Pasien pasien)
        {
            var pc = new PasiensController();

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
                if (pc.PasienExists(pasien.NIK))
                {
                    var responseMessage = "Pasien Sudah Terdaftar";
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new Exception(responseMessage)));
                }
                else
                {
                    throw;
                }
            }
           
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.Created, new Exception("Register Berhasil")));
        }

        // POST: api/Dokters
        [Route("api/RegisterDokter")]
        [ResponseType(typeof(Dokter))]
        public IHttpActionResult PostDokter(Dokter dokter)
        {
            var pc = new DoktersController();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dokters.Add(dokter);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (pc.DokterExists(dokter.NPA))
                {
                    var responseMessage = "Dokter Sudah Terdaftar";
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new Exception(responseMessage)));
                }
                else
                {
                    throw;
                }
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.Created, new Exception("Register Berhasil")));
        }

    }
}
