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
    
    public partial class eventosEntities : DbContext
    {
        public eventosEntities()
            : base("name=eventosEntities")
        {

        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion> Direccions { get; set; }
        public DbSet<Estilo> Estiloes { get; set; }
        public DbSet<Evento> Eventoes { get; set; }
        public DbSet<Flyer> Flyers { get; set; }
        public DbSet<Local> Locals { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<TipoEvento> TipoEventoes { get; set; }
        public DbSet<TipoLocal> TipoLocals { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ListaEvento> ListaEventoes { get; set; }
        public DbSet<ListaFavorito> ListaFavoritos { get; set; }
    }
}
