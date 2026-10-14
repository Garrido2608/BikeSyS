using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class RepuestoRepository : IRepuestoRepository
    {
        private readonly AppDbContext _context;

        public RepuestoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Repuesto>> ObtenerTodos()
        {
            return await _context.Repuesto
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Repuesto?> ObtenerPorId(int id)
        {
            return await _context.Repuesto
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Repuesto?> ObtenerPorNombre(string nombre)
        {
            return await _context.Repuesto
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Nombre == nombre);
        }

        public async Task<Repuesto> Crear(Repuesto repuesto)
        {
            _context.Repuesto.Add(repuesto);
            await _context.SaveChangesAsync();
            return repuesto;
        }

        public async Task<bool> Actualizar(Repuesto repuesto)
        {
            _context.Repuesto.Update(repuesto);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(Repuesto repuesto)
        {
            _context.Repuesto.Remove(repuesto);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}