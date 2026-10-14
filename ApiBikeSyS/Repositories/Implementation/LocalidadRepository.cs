using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class LocalidadRepository : ILocalidadRepository
    {
        private readonly AppDbContext _context;

        public LocalidadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Localidad>> ObtenerTodos()
        {
            return await _context.Localidad
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Localidad?> ObtenerPorId(int id)
        {
            return await _context.Localidad
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Localidad>> ObtenerPorProvincia(int idProvincia)
        {
            return await _context.Localidad
                .AsNoTracking()
                .Where(l => l.IdProvincia == idProvincia)
                .ToListAsync();
        }

        public async Task<Localidad> Crear(Localidad localidad)
        {
            _context.Localidad.Add(localidad);
            await _context.SaveChangesAsync();
            return localidad;
        }

        public async Task<bool> Actualizar(Localidad localidad)
        {
            _context.Localidad.Update(localidad);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(Localidad localidad)
        {
            _context.Localidad.Remove(localidad);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}