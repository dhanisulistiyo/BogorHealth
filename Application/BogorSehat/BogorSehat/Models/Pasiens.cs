using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BogorSehat.Models
{
    public class Pasiens : Persons
    {
        public string NIK { get; set; }
        public string Pekerjaan { get; set; }
        public string StatusPernikahan { get; set; }
       
        
    }
}