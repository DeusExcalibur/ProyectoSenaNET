using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSenaScrum.Models
{
    public class Usuario
    {
        [Key]
        [Column("id_usuario")] // Mapear a id_usuario
        public int Id { get; set; }

        [Column("nombre1")]
        [StringLength(50)]
        public string Nombre1 { get; set; }

        [Column("nombre2")]
        [StringLength(50)]
        public string Nombre2 { get; set; }

        [Column("apellido1")]
        [StringLength(50)]
        public string Apellido1 { get; set; }

        [Column("apellido2")]
        [StringLength(50)]
        public string Apellido2 { get; set; }

        [Column("tipoDocumento")]
        [StringLength(50)]
        public string TipoDocumento { get; set; }

        [Column("documento")]
        [StringLength(50)]
        public string Documento { get; set; }

        [Column("correo")]
        [StringLength(100)]
        public string Correo { get; set; }

        [Column("contrasena")]
        [StringLength(255)]
        public string Contrasena { get; set; }

        [Column("id_plan")] // Mapear a id_plan
        public int IdPlan { get; set; }
    }
}