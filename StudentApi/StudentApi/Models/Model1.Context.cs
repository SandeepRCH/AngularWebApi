﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SandeepDBEntities : DbContext
    {
        public SandeepDBEntities()
            : base("name=SandeepDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BackLogInfo> BackLogInfo { get; set; }
        public virtual DbSet<EducationalInfo> EducationalInfo { get; set; }
        public virtual DbSet<studentInfo> studentInfo { get; set; }
    }
}
