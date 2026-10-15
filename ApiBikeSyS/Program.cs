using ApiBikeSyS.Data;
using ApiBikeSyS.Mappings;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Implementation;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Implementation;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. Controladores y Explorador de Endpoints
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 2. Configuración de Swagger con soporte para JWT (Bearer)
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Autorización JWT usando el esquema Bearer. Escribí 'Bearer [espacio] tu_token' en el recuadro de abajo.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Clave JWT: NO va en el repositorio. Desarrollo: User Secrets. Produccion: variable de entorno Jwt__Key.
var jwtKey = builder.Configuration["Jwt:Key"];
if (string.IsNullOrWhiteSpace(jwtKey) || Encoding.UTF8.GetByteCount(jwtKey) < 32)
{
    throw new InvalidOperationException(
        "Falta Jwt:Key o tiene menos de 32 bytes. Configurala con: dotnet user-secrets set \"Jwt:Key\" \"<clave-aleatoria-de-32+-caracteres>\"");
}

// 3. Configuración de Autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

// 4. Configuración de CORS para el Frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// 5. Configuración de Entity Framework Core (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL")));

// 6. Configuración de AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 7. Inyección de Dependencias (Las 15 entidades de BikeSys)
builder.Services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
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

// 8. Pipeline de peticiones HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PermitirFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();