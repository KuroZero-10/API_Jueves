using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2024II.DAL;
using ShoppingAPI_Jueves_2024II.Domain.Interfaces;
using ShoppingAPI_Jueves_2024II.Domain.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Con esta linea de código que se necesita para configurar la BD
builder.Services.AddDbContext<DataBaseContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Contenedor de dependecias
builder.Services.AddScoped<ICountryService, CountryService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
