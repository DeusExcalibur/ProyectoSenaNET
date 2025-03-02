using Microsoft.AspNetCore.Mvc;

namespace ProyectoSenaScrum3.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult IniciarSesion()
        {
            return View(); // Renderiza Views/Login/IniciarSesion.cshtml
        }

        [HttpPost]
        public IActionResult IniciarSesion(string email, string password)
        {
            // Aquí puedes agregar la lógica de autenticación
            // Por ejemplo, verificar el correo y la contraseña en la base de datos

            // Si la autenticación es exitosa, redirige a la página principal
            return Json(new { redirectUrl = "/Home/Index" });

            // Si la autenticación falla, muestra un mensaje de error
            // return Json(new { error = "Correo o contraseña incorrectos" });
        }

        public IActionResult CrearCuenta()
        {
            return View(); // Renderiza Views/Login/CrearCuenta.cshtml
        }

    }
}