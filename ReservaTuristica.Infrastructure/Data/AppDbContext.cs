using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReservaTuristica.Domain.Entities;

namespace ReservaTuristica.Infrastructure.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Sede> Sedes { get; set; }

    public DbSet<Alojamiento> Alojamientos { get; set; }
}