using ReservaTuristica.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Application.Interfaces
{
    public interface IReservaService
    {
        Task CrearReservaAsync(ReservaDto dto);

        Task EliminarReservaAsync(int id);


    }
}
