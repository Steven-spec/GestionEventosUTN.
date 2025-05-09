using Microsoft.EntityFrameworkCore;
using GestionEventosAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexi�n a MariaDB/MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Configurar controladores y Swagger para la documentaci�n de la API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// Mapear los controladores
app.MapControllers();

// Ejecutar la aplicaci�n
app.Run();
