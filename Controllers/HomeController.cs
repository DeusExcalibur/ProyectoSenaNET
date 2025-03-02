using Microsoft.AspNetCore.Mvc;

namespace ProyectoSenaScrum3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Renderiza Views/Home/Index.cshtml
        }
    }
}