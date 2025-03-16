using Microsoft.EntityFrameworkCore;

namespace ProyectoSenaScrum.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PQRS> FormulariosPQRS { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<ReporteRobo> ReportesRobos { get; set; }
        public DbSet<Localidad> Localidades { get; set; } // Nuevo DbSet
    }
}