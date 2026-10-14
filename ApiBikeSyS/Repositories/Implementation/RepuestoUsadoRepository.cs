using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class RepuestoUsadoRepository : IRepuestoUsadoRepository
    {
        private readonly AppDbContext _context;

        public RepuestoUsadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RepuestoUsado>> ObtenerTodos()
        {
            return await _context.RepuestoUsado
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<RepuestoUsado?> ObtenerPorId(int id)
        {
            return await _context.RepuestoUsado
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<RepuestoUsado>> ObtenerPorOrden(int idOrdenService)
        {
            return await _context.RepuestoUsado
                .AsNoTracking()
                .Where(r => r.IdOrdenService == idOrdenService)
                .ToListAsync();
        }

        public async Task<RepuestoUsado> Crear(RepuestoUsado repuestoUsado)
        {
            _context.RepuestoUsado.Add(repuestoUsado);
            await _context.SaveChangesAsync();
            return repuestoUsado;
        }

        public async Task<bool> Actualizar(RepuestoUsado repuestoUsado)
        {
            _context.RepuestoUsado.Update(repuestoUsado);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(RepuestoUsado repuestoUsado)
        {
            _context.RepuestoUsado.Remove(repuestoUsado);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}