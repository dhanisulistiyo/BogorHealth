using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BogorSehat.Models
{
    public class Chats
    {
        public string NIK { get; set; }
        public string NPA { get; set; }
        public string Chat { get; set; }
        public System.DateTime DateTime { get; set; }

        public virtual Dokters Dokter { get; set; }
        public virtual Pasiens Pasien { get; set; }



    }
}