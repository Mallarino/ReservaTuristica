using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Application.DTOs
{
    public class ConsultarTarifaDto
    {
        public string Sede { get; set; }

        public string Alojamiento { get; set; }

        public string Temporada { get; set; }

        public decimal Monto { get; set; }

        public int CapacidadBase { get; set; }

        public decimal ValorPersonaAdicional { get; set; }
    }

}
