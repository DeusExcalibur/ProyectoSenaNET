using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace ProyectoSenaScrum.Controllers
{
    public class AdministrarController : Controller
    {
        private readonly IConfiguration _configuration;

        public AdministrarController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Administrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditarUsuario(string email, string newEmail)
        {
                                                                                                                                                        var connectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                                                                                                                                                            var query = "UPDATE proyectosena.usuarios SET correo = @newEmail WHERE correo = @email";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newEmail", newEmail);
                        command.Parameters.AddWithValue("@email", email);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Json(new { success = true, message = "Correo actualizado exitosamente." });
                        }
                        else
                        {
                            return Json(new { success = false, message = "No se encontró ningún usuario con el correo proporcionado." });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al actualizar el correo: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DeshabilitarUsuario(string email)
        {
                                                                                                                                                            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                                                                                                                                                                            var query = "DELETE FROM proyectosena.usuarios WHERE correo = @email";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Json(new { success = true, message = "Usuario deshabilitado exitosamente." });
                        }
                        else
                        {
                            return Json(new { success = false, message = "No se encontró ningún usuario con el correo proporcionado." });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al deshabilitar el usuario: " + ex.Message });
            }
        }

        [HttpPost]
        [HttpPost]
        public IActionResult VerPQRS(int pqrsId)
        {
                                                                                                                                                         var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var pqrs = new DataTable();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                                                                                                                                                                                    var query = "SELECT * FROM formulariosPQRS WHERE id_pqrs = @pqrsId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@pqrsId", pqrsId);
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(pqrs);
                    }
                }
            }

            // Convert DataTable to a list of dictionaries for JSON serialization
            var pqrsList = new List<Dictionary<string, object>>();
            foreach (DataRow row in pqrs.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in pqrs.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                pqrsList.Add(dict);
            }

            return Json(pqrsList); // Return JSON data
        }

        [HttpPost]
        public IActionResult ActualizarEstadoPQRS(int pqrsId)
        {
                                                                                                                                                                                            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                                                                                                                                                                                                var query = "UPDATE proyectosena.formulariosPQRS SET estado = 'Resuelto' WHERE id_pqrs = @pqrsId";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@pqrsId", pqrsId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Json(new { success = true, message = "Estado del PQRS actualizado exitosamente." });
                        }
                        else
                        {
                            return Json(new { success = false, message = "No se encontró ningún PQRS con el ID proporcionado." });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al actualizar el estado del PQRS: " + ex.Message });
            }
        }

        public IActionResult ComprarPremium()
        {
            return View();
        }
    }
}