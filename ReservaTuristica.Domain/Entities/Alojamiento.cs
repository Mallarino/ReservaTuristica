using ReservaTuristica.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Domain.Entities
{
    public class Alojamiento
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public int Capacidad { get; set; }

        public int CantidadHabitaciones { get; set; }

        public TipoAlojamiento Tipo { get; set; }

        public int SedeId { get; set; }

        public Sede Sede { get; set; } = null!;
    }
}
