using Microsoft.AspNetCore.Mvc;

namespace ProyectoSenaScrum3.Controllers
{
    public class ReportarController : Controller
    {
        public IActionResult Reportar()
        {
            return View();
        }

        public IActionResult Resultados()
        {
            return View();
        }

    }
}