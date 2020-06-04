using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PrestamoLibros.Models
{
    public class Cartera: DbContext 
    {
        public DbSet<AlquilerDeLibro> AlquileresDeLibro { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CopiaDeLibro> CopiasDelibro { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Materia> Materias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }





    }
}