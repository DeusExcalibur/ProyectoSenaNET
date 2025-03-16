using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using ProyectoSenaScrum.Models;
using ProyectoSenaScrum.IModel;
using ProyectoSenaScrum.Repository;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 25))));

// Registrar el repositorio
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPQRSRepository, PQRSRepository>(); // Nuevo
builder.Services.AddScoped<IReporteRepository, ReporteRepository>(); // Nuevo
builder.Services.AddScoped<IResultadoRepository, ResultadoRepository>(); // Nuevo

// Obtener la cadena de conexión desde appsettings.json
string connectionString2 = builder.Configuration.GetConnectionString("DefaultConnection");

try
{
    using (var connection = new MySqlConnection(connectionString2))
    {
        connection.Open();
        Console.WriteLine("✅ Conexión a MySQL exitosa.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error al conectar con MySQL: {ex.Message}");
}

var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP
//if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Errors/ErrorGeneral"); // Manejo de errores generales
    app.UseStatusCodePagesWithReExecute("/Errors/Error{0}"); // Manejo de errores 404, 500, etc.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Habilita el middleware de archivos estáticos
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();