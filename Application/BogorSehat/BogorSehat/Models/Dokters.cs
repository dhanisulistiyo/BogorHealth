using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BogorSehat.Models
{
    public class Dokters : Persons
    {
        public string NPA { get; set; }
        public Object Spesiali { get; set; }
    }
}