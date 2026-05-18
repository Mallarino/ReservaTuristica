using ReservaTuristica.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaTuristica.Domain.Entities
{
    public class Temporada
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public TipoTemporada Tipo { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public ICollection<Tarifa> Tarifas { get; set; } = new List<Tarifa>();

    }

}
