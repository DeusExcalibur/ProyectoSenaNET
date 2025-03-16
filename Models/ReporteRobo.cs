using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSenaScrum.Models
{
    public class ReporteRobo
    {
        [Key]
        [Column("reportes_id_reporte")]
        public int ReportesIdReporte { get; set; }

        [Column("usuarios_id_usuario")]
        public int UsuariosIdUsuario { get; set; }
    }
}