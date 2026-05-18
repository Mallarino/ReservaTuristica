using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Domain.Entities
{
    public class Reserva
    {
        public int Id { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string NombreTitular { get; set; } = string.Empty;

        public int NumeroPersonas { get; set; }

        public int NumeroHabitaciones { get; set; }

        public decimal Total { get; set; }

        public int AlojamientoId { get; set; }

        public Alojamiento Alojamiento { get; set; } = null!;

        public int TarifaId { get; set; }

        public Tarifa Tarifa { get; set; } = null!;
    }
}
