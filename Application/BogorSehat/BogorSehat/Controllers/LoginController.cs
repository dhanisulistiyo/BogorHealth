using BogorSehat.Models;
using BogorSehat.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BogorSehat.Controllers
{

    public class Login
    {
        public string NIK { get; set; }
        public string Password { get; set; }
    }
    public class LoginController : ApiController
    {
        private BogorHealthEntities db = new BogorHealthEntities();
        // POST: api/LoginPasien
        [ResponseType(typeof(Pasiens))]
        public IHttpActionResult LoginPasien(Login login)
        {
           var pasien = db.Pasiens.Where(b => b.NIK == login.NIK).FirstOrDefault();

            if (pasien == null)
            {
                //return NotFound();
                var responseMessage ="NIK not registered";
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new Exception(responseMessage)));
            }else if(pasien != null && pasien.Password != login.Password)
            {
                var responseMessage = "NIK and Password not match";
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new Exception(responseMessage)));
            }else
            {
                var p = new Pasiens();
                p.NIK = pasien.NIK;
                p.Nama = pasien.Nama;
                p.TanggalLahir = pasien.TanggalLahir;
                p.Alamat = pasien.Alamat;
                p.KotaLahir = pasien.KotaLahir;
                p.Email = pasien.Email;
                p.JenisKelamin = pasien.JenisKelamin;
                p.Pekerjaan = pasien.Pekerjaan;
                p.StatusPernikahan = pasien.StatusPernikahan;
                p.ImageUrl = pasien.ImageUrl;
                p.Agama = pasien.Agama1.Nama;
                return Ok(p);
            }






           

        }
    }
}
