using Microsoft.AspNetCore.Mvc;

namespace ProyectoSenaScrum3.Controllers
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
    }
}