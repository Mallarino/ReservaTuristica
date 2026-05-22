using ReservaTuristica.Application.DTOs;
using ReservaTuristica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Application.Interfaces
{
    public interface IReservaService
    {
        Task CrearReservaAsync(ReservaDto dto);

        Task<List<Reserva>> ObtenerReservasUsuarioAsync(string userId);

        Task EliminarReservaAsync(int id);


    }
}
