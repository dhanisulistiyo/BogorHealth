//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BogorSehat.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class RumahSakit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RumahSakit()
        {
            this.LayananRS = new HashSet<LayananR>();
        }
    
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
        public string IdAdmin { get; set; }
    
        public virtual Admin Admin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LayananR> LayananRS { get; set; }
    }
}
