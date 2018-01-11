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
    public class ChatController : ApiController
    {
        private BogorHealthEntities db = new BogorHealthEntities();
        [Route("api/ChatsHistory")]
        [ResponseType(typeof(Chats))]
        public IHttpActionResult ChatsHistory(string nik)
        {
            var chats = db.Konsultasis.Where(x => x.NIK == nik).GroupBy(x => x.NPA).Select(x=>new
            {
                NPA = x.Key
            });
            var chat = new List<Chats>();
            foreach (var item in chats)
            {

                var ch = db.Konsultasis.Where(x => x.NPA == item.NPA).Select(c => new Chats
                {
                    NIK = c.NIK,
                    NPA = c.NPA,
                    Chat = c.Chat,
                    DateTime = c.DateTime,
                    Dokter = db.Dokters.Where(x => x.NPA == item.NPA).Select(b => new Dokters
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
                    }).FirstOrDefault(),
                    Pasien = db.Pasiens.Where(x => x.NIK == c.NIK).Select(b => new Pasiens
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
                    }).FirstOrDefault()
                }).ToList();
                var lastChat = ch.LastOrDefault();
                chat.Add(lastChat);
            }
            return Ok(chat);
        }

        [Route("api/ChatsDetails")]
        [ResponseType(typeof(Chats))]
        public IHttpActionResult ChatsDetails(string nik, string npa)
        {
           
                var ch = db.Konsultasis.Where(x => x.NPA == npa && x.NIK == nik).Select(c => new Chats
                {
                    NIK = c.NIK,
                    NPA = c.NPA,
                    Chat = c.Chat,
                    DateTime = c.DateTime,
                    Dokter = db.Dokters.Select(b => new Dokters
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
                    }).FirstOrDefault(),
                    Pasien = db.Pasiens.Where(x => x.NIK == c.NIK).Select(b => new Pasiens
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
                    }).FirstOrDefault()
                }).ToList();
        
            return Ok(ch);
        }

    }
}
