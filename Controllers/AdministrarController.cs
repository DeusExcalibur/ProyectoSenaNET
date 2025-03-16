using Microsoft.AspNetCore.Mvc;

namespace ProyectoSenaScrum.Controllers
{
    public class AdministrarController : Controller
    {
        public IActionResult Administrar()
        {
            return View();
        }

        public IActionResult ComprarPremium()
        {
            return View();
        }
    }
}