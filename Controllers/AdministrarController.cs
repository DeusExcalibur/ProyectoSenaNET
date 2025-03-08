using Microsoft.AspNetCore.Mvc;

namespace ProyectoSenaScrum3.Controllers
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