﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gv1WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SandeepDBEntities2 : DbContext
    {
        public SandeepDBEntities2()
            : base("name=SandeepDBEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAlert> tblAlert { get; set; }
        public virtual DbSet<tblLoan> tblLoan { get; set; }
        public virtual DbSet<tblLoanStatus> tblLoanStatus { get; set; }
        public virtual DbSet<tblRole> tblRole { get; set; }
        public virtual DbSet<tblSetting> tblSetting { get; set; }
        public virtual DbSet<tblUser> tblUser { get; set; }
        public virtual DbSet<tblUserAlert> tblUserAlert { get; set; }
        public virtual DbSet<tblUserLoan> tblUserLoan { get; set; }
    }
}
