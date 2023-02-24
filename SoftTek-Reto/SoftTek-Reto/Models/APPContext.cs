using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Configuration;

namespace SoftTek_Reto.Models
{
    public class APPContext : DbContext
    {
        
        public APPContext(DbContextOptions<APPContext> options): 
            base(options){ }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Asesor> Asesors { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venta>(entity =>
            entity.HasOne(d => d.AsesorNav)
            .WithMany(p => p.Ventas)
            .HasForeignKey(d => d.IdAsesor)
            .HasConstraintName("FK_Vent")
            );
            modelBuilder.Entity<Venta>(entity =>
            entity.HasOne(d => d.ProductoNav)
            .WithMany(p => p.Ventas)
            .HasForeignKey(d => d.IdProducto)
            .HasConstraintName("FK_PRD")
            );
        }

    }
}
