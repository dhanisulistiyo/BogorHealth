using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BogorSehat.Models
{
    public class Persons
    {
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public Nullable<System.DateTime> TanggalLahir { get; set; }
        public string KotaLahir { get; set; }
        public string Email { get; set; }
        public string JenisKelamin { get; set; }
        public string Agama { get; set; }
        public string ImageUrl { get; set; }
    }
}