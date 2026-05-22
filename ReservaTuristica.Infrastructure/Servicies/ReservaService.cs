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
    public class ReservaService : IReservaService
    {
        private readonly AppDbContext _context;

        private readonly ITarifaService _tarifaService;

        public ReservaService(
            AppDbContext context,
            ITarifaService tarifaService)
        {
            _context = context;
            _tarifaService = tarifaService;
        }

        public async Task CrearReservaAsync(
            ReservaDto dto)
        {
            // VALIDAR FECHAS
            if (dto.FechaFin <= dto.FechaInicio)
            {
                throw new Exception(
                    "La fecha final debe ser mayor a la inicial");
            }

            // OBTENER ALOJAMIENTO
            var alojamiento = await _context.Alojamientos
                .Include(a => a.Sede)
                .FirstOrDefaultAsync(a =>
                    a.Id == dto.AlojamientoId);

            if (alojamiento == null)
            {
                throw new Exception(
                    "El alojamiento no existe");
            }

            // VALIDAR DISPONIBILIDAD
            var existeReserva = await _context.Reservas
                .AnyAsync(r =>

                    r.AlojamientoId == dto.AlojamientoId

                    &&

                    (
                        dto.FechaInicio <= r.FechaFin
                        &&
                        dto.FechaFin >= r.FechaInicio
                    )
                );

            if (existeReserva)
            {
                throw new Exception(
                    "El alojamiento no está disponible");
            }

            // OBTENER TEMPORADA
            // Por ahora dejamos Baja fija
            // luego puedes automatizarla por fechas

            var temporada = await _context.Temporadas
                .FirstOrDefaultAsync(t =>
                    t.Nombre == "Baja");

            if (temporada == null)
            {
                throw new Exception(
                    "No existe la temporada");
            }

            // CALCULAR TARIFA
            var calculo = await _tarifaService
                .CalcularTarifaAsync(
                    alojamiento.SedeId,
                    temporada.Id,
                    dto.NumeroPersonas,
                    dto.NumeroHabitaciones);

            if (calculo == null)
            {
                throw new Exception(
                    "No fue posible calcular la tarifa");
            }

            // BUSCAR TARIFA REAL
            var tarifa = await _context.Tarifas
                .Include(t => t.Alojamiento)
                .FirstOrDefaultAsync(t =>

                    t.AlojamientoId == dto.AlojamientoId

                    &&

                    t.CapacidadBase >= dto.NumeroPersonas
                );

            if (tarifa == null)
            {
                throw new Exception(
                    "No existe una tarifa válida");
            }

            // CREAR RESERVA
            var reserva = new Reserva
            {
                FechaInicio = dto.FechaInicio,

                FechaFin = dto.FechaFin,

                NombreTitular = dto.NombreTitular,

                NumeroPersonas = dto.NumeroPersonas,

                NumeroHabitaciones = dto.NumeroHabitaciones,

                Total = calculo.Total,

                AlojamientoId = dto.AlojamientoId,

                TarifaId = tarifa.Id
            };

            // GUARDAR
            _context.Reservas.Add(reserva);

            await _context.SaveChangesAsync();
        }

        public async Task EliminarReservaAsync(int id)
        {
            var reserva =
                await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                throw new Exception(
                    "La reserva no existe");
            }

            _context.Reservas.Remove(reserva);

            await _context.SaveChangesAsync();
        }
    }
}
