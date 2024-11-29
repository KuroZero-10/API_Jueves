using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2024II.DAL;
using ShoppingAPI_Jueves_2024II.Domain.Interfaces;
using ShoppingAPI_Jueves_2024II.Domain.Servicios;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Con esta linea de código que se necesita para configurar la BD
builder.Services.AddDbContext<DataBaseContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Incluye las categorias dentro de los libros, eliminando los bucles espejo
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Contenedor de dependecias
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddTransient<SeederDB>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

SeederData();
void SeederData()
{
    IServiceScopeFactory? scopedFactory=app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory.CreateScope())
    {
        SeederDB? service=scope.ServiceProvider.GetService<SeederDB?>();
        service.SeederAsync().Wait();
    }
}
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
