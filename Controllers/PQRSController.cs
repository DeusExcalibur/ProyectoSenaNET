using Microsoft.AspNetCore.Mvc;
using ProyectoSenaScrum.IModel;
using ProyectoSenaScrum.Models;
using System.Threading.Tasks;

namespace ProyectoSenaScrum.Controllers
{
    public class PQRSController : Controller
    {
        private readonly IPQRSRepository _pqrsRepository;

        public PQRSController(IPQRSRepository pqrsRepository)
        {
            _pqrsRepository = pqrsRepository;
        }

        public IActionResult pqrs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearPQRS([FromBody] PQRSModel model)
        {
            if (string.IsNullOrWhiteSpace(model.TipoPQRS) ||
                string.IsNullOrWhiteSpace(model.Descripcion) ||
                string.IsNullOrWhiteSpace(model.Estado) ||
                string.IsNullOrWhiteSpace(model.Identificador))
            {
                return BadRequest(new { error = "Todos los campos obligatorios deben estar completos." });
            }

            try
            {
                // Obtener el IdUsuario basado en el Identificador
                var idUsuario = await _pqrsRepository.GetUsuarioIdAsync(model.Identificador);
                if (idUsuario == null)
                {
                    return BadRequest(new { error = "Usuario no encontrado." });
                }

                // Crear el nuevo PQRS
                var nuevoPQRS = new PQRS
                {
                    TipoPQRS = model.TipoPQRS,
                    Descripcion = model.Descripcion,
                    Estado = model.Estado,
                    IdUsuario = idUsuario.Value
                };

                await _pqrsRepository.AddPQRSAsync(nuevoPQRS);

                return Ok(new { message = "PQRS enviada exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor: " + ex.Message });
            }
        }
    }
}