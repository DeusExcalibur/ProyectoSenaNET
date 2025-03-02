using Microsoft.AspNetCore.Mvc;

namespace ProyectoSenaScrum3.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Error404()
        {
            return View(); // Renderiza Views/Errors/Error404.cshtml
        }

        public IActionResult Error500()
        {
            return View(); // Renderiza Views/Errors/Error500.cshtml
        }
        public IActionResult ErrorGeneral()
        {
            return View(); // Renderiza Views/Errors/ErrorGeneral.cshtml
        }
    }
}