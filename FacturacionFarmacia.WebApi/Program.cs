using FacturacionFarmacia.Logica;
using FacturacionFarmacia.Logica.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Inyeccion de independencias
builder.Services.AddTransient<IProducto, ProductoDAL>();
builder.Services.AddTransient<ICliente, CLienteDAL>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
