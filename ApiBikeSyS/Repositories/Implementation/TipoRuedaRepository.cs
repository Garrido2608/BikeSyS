using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class TipoRuedaRepository : ITipoRuedaRepository
    {
        private readonly AppDbContext _context;

        public TipoRuedaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipoRueda>> ObtenerTodos()
        {
            return await _context.TipoRueda
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TipoRueda?> ObtenerPorId(int id)
        {
            return await _context.TipoRueda
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TipoRueda?> ObtenerPorNombre(string nombre)
        {
            return await _context.TipoRueda
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Nombre == nombre);
        }

        public async Task<TipoRueda> Crear(TipoRueda tipoRueda)
        {
            _context.TipoRueda.Add(tipoRueda);
            await _context.SaveChangesAsync();
            return tipoRueda;
        }

        public async Task<bool> Actualizar(TipoRueda tipoRueda)
        {
            _context.TipoRueda.Update(tipoRueda);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(TipoRueda tipoRueda)
        {
            _context.TipoRueda.Remove(tipoRueda);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}