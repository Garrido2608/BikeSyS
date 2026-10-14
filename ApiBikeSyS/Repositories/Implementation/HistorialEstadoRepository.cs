using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class HistorialEstadoRepository : IHistorialEstadoRepository
    {
        private readonly AppDbContext _context;

        public HistorialEstadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<HistorialEstado>> ObtenerTodos()
        {
            return await _context.HistorialEstado
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<HistorialEstado?> ObtenerPorId(int id)
        {
            return await _context.HistorialEstado
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<List<HistorialEstado>> ObtenerPorOrden(int idOrdenService)
        {
            return await _context.HistorialEstado
                .AsNoTracking()
                .Where(h => h.IdOrdenService == idOrdenService)
                .OrderByDescending(h => h.Fecha)
                .ToListAsync();
        }

        public async Task<HistorialEstado> Crear(HistorialEstado historial)
        {
            _context.HistorialEstado.Add(historial);
            await _context.SaveChangesAsync();
            return historial;
        }

        public async Task<bool> Actualizar(HistorialEstado historial)
        {
            _context.HistorialEstado.Update(historial);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(HistorialEstado historial)
        {
            _context.HistorialEstado.Remove(historial);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}