﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos.SqlServer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FarumEntities : DbContext
    {
        public FarumEntities()
            : base("name=FarumEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Intercambio> Intercambio { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
