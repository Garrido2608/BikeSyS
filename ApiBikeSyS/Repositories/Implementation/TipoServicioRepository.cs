using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class TipoServicioRepository : ITipoServicioRepository
    {
        private readonly AppDbContext _context;

        public TipoServicioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipoServicio>> ObtenerTodos()
        {
            return await _context.TipoServicio
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TipoServicio?> ObtenerPorId(int id)
        {
            return await _context.TipoServicio
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TipoServicio?> ObtenerPorNombre(string nombre)
        {
            return await _context.TipoServicio
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Nombre == nombre);
        }

        public async Task<TipoServicio> Crear(TipoServicio tipoServicio)
        {
            _context.TipoServicio.Add(tipoServicio);
            await _context.SaveChangesAsync();
            return tipoServicio;
        }

        public async Task<bool> Actualizar(TipoServicio tipoServicio)
        {
            _context.TipoServicio.Update(tipoServicio);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(TipoServicio tipoServicio)
        {
            _context.TipoServicio.Remove(tipoServicio);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}