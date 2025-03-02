var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllersWithViews();

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