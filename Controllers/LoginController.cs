using Microsoft.AspNetCore.Mvc;
using ProyectoSenaScrum.IModel;
using ProyectoSenaScrum.Models;
using System.Threading.Tasks;

namespace ProyectoSenaScrum.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult IniciarSesion()
        {
            return View(); // Renderiza Views/Login/IniciarSesion.cshtml
        }

        public IActionResult CrearCuenta()
        {
            return View(); // Renderiza Views/Login/CrearCuenta.cshtml
        }

        [HttpPost]
        public async Task<IActionResult> CrearCuenta([FromBody] UsuarioRegistroModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Nombre1) || string.IsNullOrWhiteSpace(model.Apellido1) ||
                string.IsNullOrWhiteSpace(model.TipoDocumento) || string.IsNullOrWhiteSpace(model.NumeroDocumento) ||
                string.IsNullOrWhiteSpace(model.Correo) || string.IsNullOrWhiteSpace(model.Password))
            {
                return BadRequest(new { error = "Todos los campos obligatorios deben estar completos." });
            }

            try
            {
                // Verificar si el usuario ya existe
                if (await _usuarioRepository.UserExistsAsync(model.Correo, model.NumeroDocumento))
                {
                    return BadRequest(new { error = "El correo o el número de documento ya están registrados." });
                }

                // Crear el nuevo usuario
                var nuevoUsuario = new Usuario
                {
                    Nombre1 = model.Nombre1,
                    Nombre2 = model.Nombre2 ?? "",
                    Apellido1 = model.Apellido1,
                    Apellido2 = model.Apellido2 ?? "",
                    TipoDocumento = model.TipoDocumento,
                    Documento = model.NumeroDocumento,
                    Correo = model.Correo,
                    Contrasena = model.Password,
                    IdPlan = 1
                };

                await _usuarioRepository.AddUsuarioAsync(nuevoUsuario);

                return Ok(new { message = "Cuenta creada exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor: " + ex.Message });
            }
        }
    }
}