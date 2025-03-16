using Microsoft.EntityFrameworkCore;
using ProyectoSenaScrum.Models;
using ProyectoSenaScrum.IModel;
using System.Threading.Tasks;

namespace ProyectoSenaScrum.Repository
{
    public class PQRSRepository : IPQRSRepository
    {
        private readonly ApplicationDbContext _context;

        public PQRSRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int?> GetUsuarioIdAsync(string identificador)
        {
            var usuario = await _context.Usuarios
                .Where(u => u.Id.ToString() == identificador) // Compara id_usuario como string
                .Select(u => (int?)u.Id)
                .FirstOrDefaultAsync();
            return usuario;
        }

        public async Task AddPQRSAsync(PQRS pqrs)
        {
            await _context.FormulariosPQRS.AddAsync(pqrs);
            await _context.SaveChangesAsync();
        }
    }
}