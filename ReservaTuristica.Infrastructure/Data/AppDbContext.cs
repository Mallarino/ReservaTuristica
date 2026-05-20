using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReservaTuristica.Application.DTOs;
using ReservaTuristica.Domain.Entities;

namespace ReservaTuristica.Infrastructure.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<AlojamientoDisponibleDto>()
            .HasNoKey();

        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Tarifa)
            .WithMany()
            .HasForeignKey(r => r.TarifaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Tarifa>()
            .Property(t => t.Monto)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Tarifa>()
           .Property(t => t.ValorPersonaAdicional)
           .HasPrecision(18, 2);

        modelBuilder.Entity<Reserva>()
            .Property(r => r.Total)
            .HasPrecision(18, 2);
    }

    public DbSet<Sede> Sedes { get; set; }

    public DbSet<Alojamiento> Alojamientos { get; set; }

    public DbSet<AlojamientoDisponibleDto> AlojamientosDisponibles { get; set; }

    public DbSet<Reserva> Reservas { get; set; }

    public DbSet<Tarifa> Tarifas { get; set; }

    public DbSet<Temporada> Temporadas { get; set; }

}