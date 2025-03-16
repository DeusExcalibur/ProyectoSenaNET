using ProyectoSenaScrum.Controllers;
using ProyectoSenaScrum.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoSenaScrum.IModel
{
    public interface IResultadoRepository
    {
        Task<List<ResultadoModel>> GetResultadosAsync(string localidad);
    }
}