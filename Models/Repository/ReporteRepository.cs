using Microsoft.EntityFrameworkCore;
using ProyectoSenaScrum.Models;
using ProyectoSenaScrum.IModel;
using System.Threading.Tasks;

namespace ProyectoSenaScrum.Repository
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly ApplicationDbContext _context;

        public ReporteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UserExistsAsync(int idUsuario)
        {
            return await _context.Usuarios.AnyAsync(u => u.Id == idUsuario);
        }

        public async Task<int> AddReporteAsync(Reporte reporte)
        {
            await _context.Reportes.AddAsync(reporte);
            await _context.SaveChangesAsync();
            return reporte.IdReporte; // Devuelve el ID generado
        }

        public async Task AddReporteRoboAsync(ReporteRobo reporteRobo)
        {
            await _context.ReportesRobos.AddAsync(reporteRobo);
            await _context.SaveChangesAsync();
        }
    }
}