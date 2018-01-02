using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BogorSehat.Models
{
    public class RumahSakits
    {
        public string IdRS { get; set; }
        public string NamaRS { get; set; }
        public string JenisRS { get; set; }
        public string KelasRS { get; set; }
        public string Deskripsi { get; set; }
        public string Visi { get; set; }
        public string Misi { get; set; }
        public string Direktur { get; set; }
        public string Alamat { get; set; }
        public string Penyelenggara { get; set; }
        public string Website { get; set; }
        public string Kota { get; set; }
        public Nullable<int> KodePos { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string ImageUrl { get; set; }


    }
}