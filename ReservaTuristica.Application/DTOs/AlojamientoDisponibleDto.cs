using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Application.DTOs
{
    public class AlojamientoDisponibleDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public int Capacidad { get; set; }

        public int CantidadHabitaciones { get; set; }

        public decimal Precio { get; set; }

        public string Sede { get; set; } = string.Empty;
    }

}
