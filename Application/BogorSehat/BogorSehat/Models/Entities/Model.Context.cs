﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BogorHealthEntities : DbContext
    {
        public BogorHealthEntities()
            : base("name=BogorHealthEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Agama> Agamas { get; set; }
        public virtual DbSet<Dokter> Dokters { get; set; }
        public virtual DbSet<JadwalLayanan> JadwalLayanans { get; set; }
        public virtual DbSet<JenisLayanan> JenisLayanans { get; set; }
        public virtual DbSet<LayananR> LayananRS { get; set; }
        public virtual DbSet<Pasien> Pasiens { get; set; }
        public virtual DbSet<RumahSakit> RumahSakits { get; set; }
        public virtual DbSet<Spesiali> Spesialis { get; set; }
        public virtual DbSet<Antrian> Antrians { get; set; }
        public virtual DbSet<Konsultasi> Konsultasis { get; set; }
    }
}
