﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HocamNerede
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WhereAUEntities : DbContext
    {
        public WhereAUEntities()
            : base("name=WhereAUEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<poolBolumDers> poolBolumDers { get; set; }
        public virtual DbSet<poolFakulteBolum> poolFakulteBolum { get; set; }
        public virtual DbSet<poolOkulFakulte> poolOkulFakulte { get; set; }
        public virtual DbSet<tblAdminLogin> tblAdminLogin { get; set; }
        public virtual DbSet<tblBolumler> tblBolumler { get; set; }
        public virtual DbSet<tblDersler> tblDersler { get; set; }
        public virtual DbSet<tblFakulteler> tblFakulteler { get; set; }
        public virtual DbSet<tblGunler> tblGunler { get; set; }
        public virtual DbSet<tblHocalar> tblHocalar { get; set; }
        public virtual DbSet<tblHvz> tblHvz { get; set; }
        public virtual DbSet<tblOkullar> tblOkullar { get; set; }
    }
}
