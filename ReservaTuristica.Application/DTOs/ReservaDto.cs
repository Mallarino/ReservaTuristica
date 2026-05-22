using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Application.DTOs
{
    public class ReservaDto
    {
        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string NombreTitular { get; set; }

        public int NumeroPersonas { get; set; }

        public int NumeroHabitaciones { get; set; }

        public int AlojamientoId { get; set; }

        public string UserId { get; set; }

    }

}
