// Context/AppDbContext.cs
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Venta> Ventas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relación Marca (1) -> Vehiculo (muchos)
        modelBuilder.Entity<Marca>()
            .HasMany(m => m.Vehiculos)
            .WithOne(v => v.Marca)
            .HasForeignKey(v => v.MarcaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación Vehiculo (1) <-> Venta (1)
        modelBuilder.Entity<Vehiculo>()
            .HasOne(v => v.Venta)
            .WithOne(vt => vt.Vehiculo)
            .HasForeignKey<Venta>(vt => vt.VehiculoId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}