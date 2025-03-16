using ProyectoSenaScrum.Models;
using System.Threading.Tasks;

namespace ProyectoSenaScrum.IModel
{
    public interface IUsuarioRepository
    {
        Task<bool> UserExistsAsync(string correo, string documento);
        Task AddUsuarioAsync(Usuario usuario);
        Task<(int IdUsuario, string Nombre, string Apellido, string Correo, string Plan)?> GetUserByCredentialsAsync(string correo, string contrasena);
    }
}