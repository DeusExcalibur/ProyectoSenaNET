using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSenaScrum.Models
{
    public class Reporte
    {
        [Key]
        [Column("id_reporte")]
        public int IdReporte { get; set; }

        [Column("metodologia_robo")]
        [StringLength(100)]
        public string MetodologiaRobo { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("fecha_robo")]
        public DateTime? FechaRobo { get; set; }

        [Column("id_localidad")]
        public int IdLocalidad { get; set; }
    }
}