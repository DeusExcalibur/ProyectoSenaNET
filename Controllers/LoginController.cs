using Microsoft.AspNetCore.Mvc;

namespace ProyectoSenaScrum3.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult IniciarSesion()
        {
            return View(); // Renderiza Views/Login/IniciarSesion.cshtml
        }

        public IActionResult CrearCuenta()
        {
            return View(); // Renderiza Views/Login/CrearCuenta.cshtml
        }

    }
}