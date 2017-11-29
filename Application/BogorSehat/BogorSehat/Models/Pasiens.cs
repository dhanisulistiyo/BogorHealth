using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BogorSehat.Models
{
    public class Pasiens
    {
        public string NIK { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public Nullable<System.DateTime> TanggalLahir { get; set; }
        public string KotaLahir { get; set; }
        public string Email { get; set; }
        public string JenisKelamin { get; set; }
        public string Pekerjaan { get; set; }
        public string StatusPernikahan { get; set; }
        public string Agama { get; set; }
        public string ImageUrl { get; set; }
        
    }
}