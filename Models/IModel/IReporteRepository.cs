using ProyectoSenaScrum.Models;
using System.Threading.Tasks;

namespace ProyectoSenaScrum.IModel
{
    public interface IReporteRepository
    {
        Task<bool> UserExistsAsync(int idUsuario);
        Task<int> AddReporteAsync(Reporte reporte);
        Task AddReporteRoboAsync(ReporteRobo reporteRobo);
    }
}