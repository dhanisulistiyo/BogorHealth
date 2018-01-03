using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BogorSehat.Models
{
    public class Antrians
    {
        public string NIK { get; set; }
        public int NoAntrian { get; set; }
        public System.DateTime TanggalDaftar { get; set; }

        public RumahSakits RumahSakit { get; set; }
        public Pasiens Pasien { get; set; }
    }
}