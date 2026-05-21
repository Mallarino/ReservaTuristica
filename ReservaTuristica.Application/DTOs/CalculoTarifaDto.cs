using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Application.DTOs
{
    public class CalculoTarifaDto
    {
        public decimal MontoBase { get; set; }

        public int CapacidadBase { get; set; }

        public int PersonasAdicionales { get; set; }

        public decimal ValorPersonaAdicional { get; set; }

        public decimal Total { get; set; }
    }
}
