using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient; // Asegúrate de instalar el paquete MySql.Data
using System.Threading.Tasks;

namespace ProyectoSenaScrum3.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString = "Server=127.0.0.1;Database=proyectosena;User=root;Password=;";

        public IActionResult Index()
        {
            return View(); // Renderiza Views/Home/Index.cshtml
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginRequest request)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = @"
                    SELECT usuarios.correo, usuarios.contrasena, usuarios.nombre1 AS nombre, usuarios.apellido1 AS apellido, planes.nombre_plan 
                    FROM usuarios 
                    INNER JOIN planes ON usuarios.id_plan = planes.id_plan
                    WHERE usuarios.correo = @Correo AND usuarios.contrasena = @Contrasena";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Correo", request.Email);
                    cmd.Parameters.AddWithValue("@Contrasena", request.Password);

                    using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            var nombre = reader["nombre"].ToString();
                            var apellido = reader["apellido"].ToString();
                            var correo = reader["correo"].ToString();
                            var plan = reader["nombre_plan"].ToString().ToLower().Trim();

                            string pagina = "PaginaLoggeada";
                            if (plan == "premium") pagina = "PaginaPremium";
                            else if (plan == "admin") pagina = "PaginaAdministrador";

                            var url = Url.Action(pagina, "Home", new { nombre, apellido, plan, correo });

                            return Json(new { redirectUrl = url });
                        }
                        else
                        {
                            return Unauthorized(new { error = "Correo o contraseña incorrectos" });
                        }
                    }
                }
            }
        }

        public IActionResult PaginaLoggeada(string nombre, string apellido, string plan, string correo)
        {
            ViewData["Nombre"] = nombre;
            ViewData["Apellido"] = apellido;
            ViewData["Plan"] = plan;
            ViewData["Correo"] = correo;
            return View();
        }

        public IActionResult PaginaPremium(string nombre, string apellido, string plan, string correo)
        {
            ViewData["Nombre"] = nombre;
            ViewData["Apellido"] = apellido;
            ViewData["Plan"] = plan;
            ViewData["Correo"] = correo;
            return View();
        }

        public IActionResult PaginaAdministrador(string nombre, string apellido, string plan, string correo)
        {
            ViewData["Nombre"] = nombre;
            ViewData["Apellido"] = apellido;
            ViewData["Plan"] = plan;
            ViewData["Correo"] = correo;
            return View();
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}