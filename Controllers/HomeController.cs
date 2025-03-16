using Microsoft.AspNetCore.Mvc;
using ProyectoSenaScrum.IModel;
using ProyectoSenaScrum.Models;
using System.Threading.Tasks;

namespace ProyectoSenaScrum.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public HomeController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View(); // Renderiza Views/Home/Index.cshtml
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginRequest request)
        {
            var userData = await _usuarioRepository.GetUserByCredentialsAsync(request.Email, request.Password);
            if (userData == null)
            {
                return Unauthorized(new { error = "Correo o contraseña incorrectos" });
            }

            var (identificador, nombre, apellido, correo, plan) = userData.Value;

            string pagina = "PaginaLoggeada";
            if (plan.ToLower().Trim() == "premium") pagina = "PaginaPremium";
            else if (plan.ToLower().Trim() == "admin") pagina = "PaginaAdministrador";

            var url = Url.Action(pagina, "Home", new { identificador, nombre, apellido, plan, correo });

            return Json(new { redirectUrl = url });
        }

        public IActionResult PaginaLoggeada(string identificador, string nombre, string apellido, string plan, string correo)
        {
            ViewData["Identificador"] = identificador;
            ViewData["Nombre"] = nombre;
            ViewData["Apellido"] = apellido;
            ViewData["Plan"] = plan;
            ViewData["Correo"] = correo;
            return View();
        }

        public IActionResult PaginaPremium(string identificador, string nombre, string apellido, string plan, string correo)
        {
            ViewData["Identificador"] = identificador;
            ViewData["Nombre"] = nombre;
            ViewData["Apellido"] = apellido;
            ViewData["Plan"] = plan;
            ViewData["Correo"] = correo;
            return View();
        }

        public IActionResult PaginaAdministrador(string identificador, string nombre, string apellido, string plan, string correo)
        {
            ViewData["Identificador"] = identificador;
            ViewData["Nombre"] = nombre;
            ViewData["Apellido"] = apellido;
            ViewData["Plan"] = plan;
            ViewData["Correo"] = correo;
            return View();
        }
    }
}