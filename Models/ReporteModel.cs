using System;

namespace ProyectoSenaScrum.Models
{
    public class ReporteModel
    {
        public string MetodologiaRobo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRobo { get; set; }
        public int IdLocalidad { get; set; }
        public string Identificador { get; set; } // Viene como string desde localStorage
    }
}