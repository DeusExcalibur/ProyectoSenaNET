using Microsoft.AspNetCore.Mvc;

namespace ProyectoSenaScrum.Controllers
{
    public class StaticPageController : Controller
    {
        public IActionResult AcercaDeNosotros()
        {
            return View(); // Renderiza Views/StaticPage/AcercaDeNosotros.cshtml
        }

        public IActionResult PrivacidadCondiciones()
        {
            return View(); // Renderiza Views/StaticPage/PrivacidadCondiciones.cshtml
        }

        public IActionResult MapaNavegacion()
        {
            return View(); // Renderiza Views/StaticPage/PrivacidadCondiciones.cshtml
        }

        public IActionResult Planes()
        {
            return View(); // Renderiza Views/StaticPage/PrivacidadCondiciones.cshtml
        }
    }
}