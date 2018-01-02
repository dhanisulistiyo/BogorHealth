using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BogorSehat.Models
{
    public class LayananRS
    {
        public string IdLayanan { get; set; }
        public string IdRS { get; set; }
        public string IdLayananRS { get; set; }
        public virtual Object Layanan { get; set; }
    }
}