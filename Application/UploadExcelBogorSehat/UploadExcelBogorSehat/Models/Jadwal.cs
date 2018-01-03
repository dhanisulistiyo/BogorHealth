using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadExcelBogorSehat.Models
{
    class Jadwal
    {
        public int IdJadwal { get; set; }
        public string IdLayananRS { get; set; }
        public string IdDokter { get; set; }
        public string Hari { get; set; }
        public DateTime JamMulai { get; set; }
        public DateTime JamSelesai { get; set; }
    }
}
