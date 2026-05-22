using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReservaTuristica.Application.DTOs;
using ReservaTuristica.Application.Interfaces;
using ReservaTuristica.Domain.Entities;
using ReservaTuristica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Infrastructure.Servicies
{
    public class DisponibilidadService : IDisponibilidadService
    {
        private readonly AppDbContext _context;

        private readonly ITarifaService _tarifaService;

        public DisponibilidadService(AppDbContext context, ITarifaService tarifaService)
        {
            _context = context;
            _tarifaService = tarifaService;
        }

        //public async Task<List<AlojamientoDisponibleDto>>
        //    ObtenerDisponiblesAsync(
        //        DateTime fechaInicio,
        //        DateTime fechaFin)
        //{
        //    var fechaInicioParam =
        //        new SqlParameter("@FechaInicio", fechaInicio);

        //    var fechaFinParam =
        //        new SqlParameter("@FechaFin", fechaFin);

        //    return await _context
        //        .Set<AlojamientoDisponibleDto>()
        //        .FromSqlRaw(
        //            "EXEC sp_HabitacionesDisponibles @FechaInicio, @FechaFin",
        //            fechaInicioParam,
        //            fechaFinParam)
        //        .ToListAsync();
        //}

        public async Task<List<AlojamientoDisponibleDto>>
            ObtenerDisponiblesPorPersonasAsync(
                DateTime fechaInicio,
                DateTime fechaFin,
                int numeroPersonas,
                int numeroHabitaciones,
                int temporadaId)
        {
            var fechaInicioParam =
                new SqlParameter("@FechaInicio", fechaInicio);

            var fechaFinParam =
                new SqlParameter("@FechaFin", fechaFin);

            var personasParam =
                new SqlParameter("@NumeroPersonas", numeroPersonas);

            var disponibles = await _context
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

            var temporada = await _context.Temporadas
                .FirstOrDefaultAsync(t =>

                    fechaInicio >= t.FechaInicio
                        &&

                    fechaInicio <= t.FechaFin
                );

            if (temporada == null)
            {
                throw new Exception(
                    "No existe temporada para esa fecha");
            }

            foreach (var alojamiento in disponibles)
            {
                try
                {
                    var alojamientoEntity =
                        await _context.Alojamientos
                            .FirstOrDefaultAsync(a =>
                                a.Id ==
                                alojamiento.Id);

                    if (alojamientoEntity == null)
                        continue;

                    var tarifa =
                        await _tarifaService
                            .CalcularTarifaAsync(
                                alojamientoEntity.SedeId,
                                temporada.Id,
                                numeroPersonas,
                                alojamientoEntity.CantidadHabitaciones
                                );
                    

                    if (tarifa != null)
                    {
                        alojamiento.Precio =
                            tarifa.Total;
                    }
                }
                catch
                {
                    alojamiento.Precio = 0;
                }
            }

            return disponibles;

        }
    }
}
