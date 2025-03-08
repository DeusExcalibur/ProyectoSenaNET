using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllersWithViews();

// Obtener la cadena de conexión desde appsettings.json
string connectionString = builder.Configuration.GetConnectionString("MySQLConnection");

try
{
    using (var connection = new MySqlConnection(connectionString))
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