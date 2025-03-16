using Microsoft.EntityFrameworkCore;
using ProyectoSenaScrum.Models;
using ProyectoSenaScrum.IModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoSenaScrum.Controllers;

namespace ProyectoSenaScrum.Repository
{
    public class ResultadoRepository : IResultadoRepository
    {
        private readonly ApplicationDbContext _context;

        public ResultadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResultadoModel>> GetResultadosAsync(string localidad)
        {
            var resultados = await _context.Localidades
                .Join(_context.Reportes,
                    l => l.IdLocalidad,
                    r => r.IdLocalidad,
                    (l, r) => new { Localidad = l, Reporte = r })
                .Join(_context.ReportesRobos,
                    lr => lr.Reporte.IdReporte,
                    rr => rr.ReportesIdReporte,
                    (lr, rr) => new { lr.Localidad, lr.Reporte, ReporteRobo = rr })
                .Join(_context.Usuarios,
                    lrr => lrr.ReporteRobo.UsuariosIdUsuario,
                    u => u.Id,
                    (lrr, u) => new ResultadoModel
                    {
                        NombreLocalidad = lrr.Localidad.NombreLocalidad,
                        Nombre = u.Nombre1 + " " + (u.Nombre2 ?? "") + " " + u.Apellido1 + " " + u.Apellido2,
                        MetodologiaRobo = lrr.Reporte.MetodologiaRobo,
                        Descripcion = lrr.Reporte.Descripcion,
                        FechaRobo = lrr.Reporte.FechaRobo ?? DateTime.MinValue // Maneja NULL
                    })
                .Where(result => EF.Functions.Like(result.NombreLocalidad, $"%{localidad}%"))
                .ToListAsync();

            return resultados;
        }
    }
}