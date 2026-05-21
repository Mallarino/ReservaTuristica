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
    public class TarifaService : ITarifaService
    {
        private readonly AppDbContext _context;

        public TarifaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CalculoTarifaDto>
            CalcularTarifaAsync(
                int sedeId,
                int temporadaId,
                int numeroPersonas,
                int numeroHabitaciones)
        {
            var sedeIdParam =
                new SqlParameter("@SedeId", sedeId);

            var temporadaIdParam =
                new SqlParameter("@TemporadaId", temporadaId);

            var numeroPersonasParam =
                new SqlParameter("@NumeroPersonas", numeroPersonas);

            var numeroHabitacionesParam =
                new SqlParameter("@NumeroHabitaciones", numeroHabitaciones);

            var resultado = await _context
                .Set<CalculoTarifaDto>()
                .FromSqlRaw(
                    "EXEC sp_CalcularTarifa @SedeId, @TemporadaId, @NumeroPersonas, @NumeroHabitaciones",
                    sedeIdParam,
                    temporadaIdParam,
                    numeroPersonasParam,
                    numeroHabitacionesParam)
                .ToListAsync();

            return resultado.FirstOrDefault();

        }

        public async Task<List<ConsultarTarifaDto>>
            ConsultarTarifaAsync(
                int sedeId,
                int temporadaId,
                int numeroPersonas
                )
        {
            var sedeIdoParam =
                new SqlParameter("@SedeId", sedeId);

            var temporadaIdParam =
                new SqlParameter("@TemporadaId", temporadaId);

            var numeroPersonasdParam =
                new SqlParameter("@NumeroPersonas", numeroPersonas);

            return await _context
                .Set<ConsultarTarifaDto>()
                .FromSqlRaw(
                    "EXEC sp_ConsultarTarifas @SedeId, @TemporadaId, @NumeroPersonas",
                    sedeIdoParam,
                    temporadaIdParam,
                    numeroPersonasdParam)
                .ToListAsync();
        }
    }
}
