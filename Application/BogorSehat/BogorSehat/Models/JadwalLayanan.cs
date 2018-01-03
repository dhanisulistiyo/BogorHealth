using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BogorSehat.Models
{
    public class JadwalLayanans
    {
        public string IdJadwal { get; set; }
        public string Hari { get; set; }
        public System.TimeSpan JamMulai { get; set; }
        public System.TimeSpan JamSelesai { get; set; }
        public virtual Object Dokter { get; set; }
    }

    public class Jadwal
    {
        public string Hari { get; set; }
        public virtual ICollection<JadwalLayanans> JadwalLayanan { get; set; }

    }
}