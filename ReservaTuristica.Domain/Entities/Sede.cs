
using ReservaTuristica.Domain.Enums;

namespace ReservaTuristica.Domain.Entities
{
    public class Sede
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Ciudad { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public int CapacidadTotal { get; set; }

        public TipoSede Tipo { get; set; }

        public ICollection<Alojamiento> Alojamientos { get; set; }
            = new List<Alojamiento>();
    }
}
