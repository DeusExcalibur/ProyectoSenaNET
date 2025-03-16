using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSenaScrum.Models
{
    public class PQRS
    {
        [Key]
        [Column("id_pqrs")]
        public int IdPQRS { get; set; }

        [Column("tipo_pqrs")]
        [Required]
        public string TipoPQRS { get; set; } // Podrías usar un enum aquí si prefieres

        [Column("descripcion")]
        [Required]
        public string Descripcion { get; set; }

        [Column("estado")]
        [Required]
        public string Estado { get; set; } // Podrías usar un enum aquí si prefieres

        [Column("id_usuario")]
        public int IdUsuario { get; set; }
    }
}