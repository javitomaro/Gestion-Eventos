﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionEventos.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gestioneventosEntities : DbContext
    {
        public gestioneventosEntities()
            : base("name=gestioneventosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<cliente> clientes { get; set; }
        public DbSet<direccion> direccions { get; set; }
        public DbSet<estilo> estiloes { get; set; }
        public DbSet<evento> eventoes { get; set; }
        public DbSet<flyer> flyers { get; set; }
        public DbSet<listaevento> listaeventoes { get; set; }
        public DbSet<listafavorito> listafavoritos { get; set; }
        public DbSet<local> locals { get; set; }
        public DbSet<tipoevento> tipoeventoes { get; set; }
        public DbSet<tipolocal> tipolocals { get; set; }
    }
}
