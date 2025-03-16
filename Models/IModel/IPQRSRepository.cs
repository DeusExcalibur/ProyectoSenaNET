using ProyectoSenaScrum.Models;
using System.Threading.Tasks;

namespace ProyectoSenaScrum.IModel
{
    public interface IPQRSRepository
    {
        Task<int?> GetUsuarioIdAsync(string identificador);
        Task AddPQRSAsync(PQRS pqrs);
    }
}