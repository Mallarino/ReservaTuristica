using ReservaTuristica.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Application.Interfaces
{
    public interface ITarifaService
    {

        Task<CalculoTarifaDto> CalcularTarifaAsync(
            int sedeId,
            int temporadaId,
            int numeroPersonas,
            int numeroHabitaciones
        );

        Task<List<ConsultarTarifaDto>> ConsultarTarifaAsync(
            int sedeId,
            int temporadaId,
            int numeroPersonas
        );



    }
}
