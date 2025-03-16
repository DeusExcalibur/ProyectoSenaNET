using Microsoft.AspNetCore.Mvc;
using ProyectoSenaScrum.IModel;
using ProyectoSenaScrum.Models;
using System;
using System.Threading.Tasks;

namespace ProyectoSenaScrum.Controllers
{
    public class ReportesController : Controller
    {
        private readonly IReporteRepository _reporteRepository;

        public ReportesController(IReporteRepository reporteRepository)
        {
            _reporteRepository = reporteRepository;
        }

        public IActionResult Reportar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnviarReporte([FromBody] ReporteModel model)
        {
            if (string.IsNullOrWhiteSpace(model.MetodologiaRobo) ||
                string.IsNullOrWhiteSpace(model.Descripcion) ||
                model.FechaRobo == default(DateTime) ||
                model.IdLocalidad <= 0 ||
                string.IsNullOrWhiteSpace(model.Identificador))
            {
                return BadRequest(new { error = "Todos los campos obligatorios deben estar completos." });
            }

            try
            {
                if (!int.TryParse(model.Identificador, out int idUsuario))
                {
                    return BadRequest(new { error = "El identificador del usuario no es válido." });
                }

                if (!await _reporteRepository.UserExistsAsync(idUsuario))
                {
                    return BadRequest(new { error = "Usuario no encontrado." });
                }

                var nuevoReporte = new Reporte
                {
                    MetodologiaRobo = model.MetodologiaRobo,
                    Descripcion = model.Descripcion,
                    FechaRobo = model.FechaRobo,
                    IdLocalidad = model.IdLocalidad
                };

                int reportId = await _reporteRepository.AddReporteAsync(nuevoReporte);

                var reporteRobo = new ReporteRobo
                {
                    ReportesIdReporte = reportId,
                    UsuariosIdUsuario = idUsuario
                };

                await _reporteRepository.AddReporteRoboAsync(reporteRobo);

                return Ok(new { message = "Reporte enviado exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor: " + ex.Message });
            }
        }
    }
}