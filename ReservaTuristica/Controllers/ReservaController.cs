using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaTuristica.Application.DTOs;
using ReservaTuristica.Application.Interfaces;
using ReservaTuristica.Domain.Entities;
using ReservaTuristica.Infrastructure.Data;
using System.Security.Claims;

namespace ReservaTuristica.Web.Controllers
{
    [Authorize]
    public class ReservaController: Controller
    {
        private readonly IReservaService _service;

        private readonly AppDbContext _context;

        public ReservaController(
        IReservaService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }
        // GET
        [HttpGet]
        public IActionResult Crear(int alojamientoId,
            DateTime fechaInicio,
            DateTime fechaFin,
            int numeroPersonas, 
            int numeroHabitaciones)
        {
            var dto = new ReservaDto
            {
                AlojamientoId = alojamientoId,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                NumeroPersonas = numeroPersonas,
                NumeroHabitaciones = numeroHabitaciones,

            };

            return View(dto);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Crear(
            ReservaDto dto)
        {
            try
            {
                var userId =
                    User.FindFirstValue(
                        ClaimTypes.NameIdentifier);

                dto.UserId = userId;

                await _service.CrearReservaAsync(dto);


                ViewBag.Mensaje =
                    "Reserva creada correctamente";

                return View(new ReservaDto());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                ViewBag.Alojamientos =
                    _context.Alojamientos.ToList();

                return View(dto);
            }
        }

        //VER MIS RESERVAS
        public async Task<IActionResult>
            MisReservas()
        {
            var userId =
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier);

            var reservas =
                await _service
                    .ObtenerReservasUsuarioAsync(
                        userId);

            return View(reservas);
        }

        // ELIMINAR
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.EliminarReservaAsync(id);

                return RedirectToAction(
                    "Index",
                    "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View();
            }
        }
    }
}
