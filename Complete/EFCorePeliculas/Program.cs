using EFCorePeliculas;
using EFCorePeliculas.CompiledModels;
using EFCorePeliculas.Servicios;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// ignoracion los ciclos de JSON
builder.Services.AddControllers().AddJsonOptions(opciones =>
       opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
{
    opciones.UseSqlServer(connectionString, sqlServer => sqlServer.UseNetTopologySuite());
    // Comportamiento defecto de las Query No tracking
    opciones.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //opciones.UseModel(ApplicationDbContextModel.Instance);
    //opciones.UseLazyLoadingProxies();
}
);

//builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddScoped<IActualizadorObservableCollection, ActualizadorObservableCollection>();
builder.Services.AddScoped<IServicioUsuario, ServicioUsuario>();
builder.Services.AddScoped<IEventosDbContext, EventosDbContext>();

builder.Services.AddAutoMapper(typeof(Program));

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
