﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class vmcEntities2 : DbContext
    {
        public vmcEntities2()
            : base("name=vmcEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_vehicle> tbl_vehicle { get; set; }
        public virtual DbSet<tbl_vehicletype> tbl_vehicletype { get; set; }
        public virtual DbSet<tbl_Car> tbl_Car { get; set; }
        public virtual DbSet<tbl_bike> tbl_bike { get; set; }
    }
}
