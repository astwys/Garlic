﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Garlic_WebClient.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class garlicEntities : DbContext
    {
        public garlicEntities()
            : base("name=garlicEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<a_articles> a_articles { get; set; }
        public virtual DbSet<c_clove> c_clove { get; set; }
        public virtual DbSet<csm_connectedsocialmedias> csm_connectedsocialmedias { get; set; }
        public virtual DbSet<p_posts> p_posts { get; set; }
        public virtual DbSet<r_rankings> r_rankings { get; set; }
        public virtual DbSet<sm_socialmedias> sm_socialmedias { get; set; }
        public virtual DbSet<u_users> u_users { get; set; }
        public virtual DbSet<v_votes> v_votes { get; set; }
        public virtual DbSet<vclovearticles> vclovearticles { get; set; }
        public virtual DbSet<vcloveinfo> vcloveinfo { get; set; }
        public virtual DbSet<vpostinfo> vpostinfo { get; set; }
        public virtual DbSet<vuserrankings> vuserrankings { get; set; }
        public virtual DbSet<vuservotes> vuservotes { get; set; }
    }
}
