using Microsoft.AspNetCore.Mvc;
using ReservaTuristica.Application.Interfaces;

namespace ReservaTuristica.Web.Controllers
{
    public class TarifaController : Controller
    {
        private readonly ITarifaService _service;

        public TarifaController(
            ITarifaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(
            int sedeId,
            int temporadaId,
            int numeroPersonas,
            int numeroHabitaciones)
        {
            try
            {
                var tarifa =
                await _service.CalcularTarifaAsync(
                    sedeId,
                    temporadaId,
                    numeroPersonas,
                    numeroHabitaciones);

                return View(tarifa);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
            
        }

        public async Task<IActionResult> Consultar(
            int sedeId,
            int temporadaId,
            int numeroPersonas
            )
        {
            var tarifas =
                await _service.ConsultarTarifaAsync(
                    sedeId,
                    temporadaId,
                    numeroPersonas
                    );

            return View(tarifas);
        }

    }

}
