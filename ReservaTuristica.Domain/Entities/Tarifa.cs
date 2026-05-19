using ReservaTuristica.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Domain.Entities
{
    public class Tarifa
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal Monto { get; set; }

        public int CapacidadBase { get; set; }

        public decimal ValorPersonaAdicional { get; set; }

        public int TemporadaId { get; set; }

        public Temporada Temporada { get; set; } = null!;

        public int AlojamientoId { get; set; }

        public Alojamiento Alojamiento { get; set; } = null!;
    }

}
