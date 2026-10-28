using ApiBikeSyS.Data;
using ApiBikeSyS.Mappings;
using ApiBikeSyS.Repositories.Implementation;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Implementation;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//  Controladores y Explorador de Endpoints
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//  Configuración de CORS para el Frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

//  Configuración de Entity Framework Core (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL")));

//  Configuración de AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//  Inyección de Dependencias entidades
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<IProvinciaRepository, ProvinciaRepository>();
builder.Services.AddScoped<IProvinciaService, ProvinciaService>();

builder.Services.AddScoped<ILocalidadRepository, LocalidadRepository>();
builder.Services.AddScoped<ILocalidadService, LocalidadService>();

builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<IMarcaService, MarcaService>();

builder.Services.AddScoped<IModeloRepository, ModeloRepository>();
builder.Services.AddScoped<IModeloService, ModeloService>();

builder.Services.AddScoped<ITipoRuedaRepository, TipoRuedaRepository>();
builder.Services.AddScoped<ITipoRuedaService, TipoRuedaService>();

builder.Services.AddScoped<IBicicletaRepository, BicicletaRepository>();
builder.Services.AddScoped<IBicicletaService, BicicletaService>();

builder.Services.AddScoped<IRepuestoRepository, RepuestoRepository>();
builder.Services.AddScoped<IRepuestoService, RepuestoService>();

builder.Services.AddScoped<ITipoServicioRepository, TipoServicioRepository>();
builder.Services.AddScoped<ITipoServicioService, TipoServicioService>();

builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddScoped<IEstadoService, EstadoService>();

builder.Services.AddScoped<IOrdenServiceRepository, OrdenServiceRepository>();
builder.Services.AddScoped<IOrdenServiceService, OrdenServiceService>();

builder.Services.AddScoped<IHistorialEstadoRepository, HistorialEstadoRepository>();
builder.Services.AddScoped<IHistorialEstadoService, HistorialEstadoService>();

builder.Services.AddScoped<IRepuestoUsadoRepository, RepuestoUsadoRepository>();
builder.Services.AddScoped<IRepuestoUsadoService, RepuestoUsadoService>();

builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<IServicioService, ServicioService>();

var app = builder.Build();

// Pipeline de peticiones HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PermitirFrontend");

// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();