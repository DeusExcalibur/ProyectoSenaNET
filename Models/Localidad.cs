using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSenaScrum.Models
{
    public class Localidad
    {
        [Key]
        [Column("id_localidad")]
        public int IdLocalidad { get; set; }

        [Column("nombre_localidad")]
        [StringLength(100)]
        public string NombreLocalidad { get; set; }
    }
}