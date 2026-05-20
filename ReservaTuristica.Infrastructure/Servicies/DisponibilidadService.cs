using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReservaTuristica.Application.DTOs;
using ReservaTuristica.Application.Interfaces;
using ReservaTuristica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Infrastructure.Servicies
{
    public class DisponibilidadService : IDisponibilidadService
    {
        private readonly AppDbContext _context;

        public DisponibilidadService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AlojamientoDisponibleDto>>
            ObtenerDisponiblesAsync(
                DateTime fechaInicio,
                DateTime fechaFin)
        {
            var fechaInicioParam =
                new SqlParameter("@FechaInicio", fechaInicio);

            var fechaFinParam =
                new SqlParameter("@FechaFin", fechaFin);

            return await _context
                .Set<AlojamientoDisponibleDto>()
                .FromSqlRaw(
                    "EXEC sp_HabitacionesDisponibles @FechaInicio, @FechaFin",
                    fechaInicioParam,
                    fechaFinParam)
                .ToListAsync();
        }

        public async Task<List<AlojamientoDisponibleDto>>
            ObtenerDisponiblesPorPersonasAsync(
                DateTime fechaInicio,
                DateTime fechaFin,
                int numeroPersonas)
        {
            var fechaInicioParam =
                new SqlParameter("@FechaInicio", fechaInicio);

            var fechaFinParam =
                new SqlParameter("@FechaFin", fechaFin);

            var personasParam =
                new SqlParameter("@NumeroPersonas", numeroPersonas);

            return await _context
                .Set<AlojamientoDisponibleDto>()
                .FromSqlRaw(
                    @"EXEC sp_HabitacionesDisponiblesPorPersonas
                @FechaInicio,
                @FechaFin,
                @NumeroPersonas",
                    fechaInicioParam,
                    fechaFinParam,
                    personasParam)
                .ToListAsync();
        }
    }
}
