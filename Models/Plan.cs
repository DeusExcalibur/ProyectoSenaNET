using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSenaScrum.Models
{
    public class Plan
    {
        [Key]
        [Column("id_plan")]
        public int IdPlan { get; set; }

        [Column("nombre_plan")]
        [StringLength(100)]
        public string NombrePlan { get; set; }

        [Column("precio")]
        public int Precio { get; set; }
    }
}