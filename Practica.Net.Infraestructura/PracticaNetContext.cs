
using Microsoft.EntityFrameworkCore;
using OrganicSoft.Infraestructura.Base;
using Practica.Net.Dominio;
using System;

namespace Practica.Net.Infraestructura
{
    public class PracticaNetContext : DbContextBase
    {
        public PracticaNetContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Persona> Persona { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().HasKey(c => c.Id);
     
        }
    }
}
