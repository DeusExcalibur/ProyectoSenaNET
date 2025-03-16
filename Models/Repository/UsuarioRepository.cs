using Microsoft.EntityFrameworkCore;
using ProyectoSenaScrum.Models;
using ProyectoSenaScrum.IModel;
using System.Threading.Tasks;

namespace ProyectoSenaScrum.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UserExistsAsync(string correo, string documento)
        {
            return await _context.Usuarios
                .AnyAsync(u => u.Correo == correo || u.Documento == documento);
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<(int IdUsuario, string Nombre, string Apellido, string Correo, string Plan)?> GetUserByCredentialsAsync(string correo, string contrasena)
        {
            var result = await _context.Usuarios
                .Join(_context.Planes,
                    usuario => usuario.IdPlan,
                    plan => plan.IdPlan,
                    (usuario, plan) => new { usuario, plan })
                .Where(up => up.usuario.Correo == correo && up.usuario.Contrasena == contrasena)
                .Select(up => new
                {
                    IdUsuario = up.usuario.Id,
                    Nombre = up.usuario.Nombre1,
                    Apellido = up.usuario.Apellido1,
                    Correo = up.usuario.Correo,
                    Plan = up.plan.NombrePlan
                })
                .FirstOrDefaultAsync();

            if (result == null) return null;

            return (result.IdUsuario, result.Nombre, result.Apellido, result.Correo, result.Plan);
        }
    }
}