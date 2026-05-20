using Microsoft.AspNetCore.Mvc;
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
            DateTime fechaInicio,
            DateTime fechaFin)
        {
            var disponibles =
                await _service.ObtenerDisponiblesAsync(
                    fechaInicio,
                    fechaFin);

            return View(disponibles);
        }
    }
}
