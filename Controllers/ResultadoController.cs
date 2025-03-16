using Microsoft.AspNetCore.Mvc;
using ProyectoSenaScrum.IModel;
using ProyectoSenaScrum.Models;
using System.Threading.Tasks;

namespace ProyectoSenaScrum.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly IResultadoRepository _resultadoRepository;

        public ResultadoController(IResultadoRepository resultadoRepository)
        {
            _resultadoRepository = resultadoRepository;
        }

        public IActionResult Resultados()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetResultados(string localidad)
        {
            if (string.IsNullOrEmpty(localidad))
            {
                return BadRequest(new { error = "La localidad es requerida" });
            }

            try
            {
                var resultados = await _resultadoRepository.GetResultadosAsync(localidad);
                return Json(resultados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor: " + ex.Message });
            }
        }
    }
}