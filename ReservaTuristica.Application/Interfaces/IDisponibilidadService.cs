using ReservaTuristica.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Application.Interfaces
{
    public interface IDisponibilidadService
    {
        Task<List<AlojamientoDisponibleDto>> ObtenerDisponiblesAsync(
        DateTime fechaInicio,
        DateTime fechaFin);

        Task<List<AlojamientoDisponibleDto>> ObtenerDisponiblesPorPersonasAsync(
            DateTime fechaInicio,
            DateTime fechaFin,
            int numeroPersonas);
    }

}
