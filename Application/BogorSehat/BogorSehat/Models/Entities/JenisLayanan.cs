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
    
    public partial class JenisLayanan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JenisLayanan()
        {
            this.LayananRS = new HashSet<LayananR>();
        }
    
        public string IdLayanan { get; set; }
        public string JenisLayanan1 { get; set; }
        public string Deskripsi { get; set; }
        public string ImageUrl { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LayananR> LayananRS { get; set; }
    }
}
