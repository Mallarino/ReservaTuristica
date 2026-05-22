using Microsoft.AspNetCore.Mvc;
using ReservaTuristica.Application.DTOs;
using ReservaTuristica.Application.Interfaces;

namespace ReservaTuristica.Web.Controllers
{
    public class DisponibilidadController : Controller
    {
        private readonly IDisponibilidadService _service;

        public DisponibilidadController(
            IDisponibilidadService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(
            DateTime? fechaInicio,
            DateTime? fechaFin,
            int numeroPersonas,
            int numeroHabitaciones,
            int temporadaId
            )
        {

            if (!fechaInicio.HasValue || !fechaFin.HasValue)
            {
                return View(new List<AlojamientoDisponibleDto>());
            }

            var disponibles =
                await _service.ObtenerDisponiblesPorPersonasAsync(
                    fechaInicio.Value,
                    fechaFin.Value,
                    numeroPersonas,
                    numeroHabitaciones,
                    temporadaId);

            return View(disponibles);
        }
    }
}
