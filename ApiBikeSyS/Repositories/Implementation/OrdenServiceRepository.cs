using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class OrdenServiceRepository : IOrdenServiceRepository
    {
        private readonly AppDbContext _context;

        public OrdenServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrdenService>> ObtenerTodos()
        {
            return await _context.OrdenService
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OrdenService?> ObtenerPorId(int id)
        {
            return await _context.OrdenService
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<OrdenService> Crear(OrdenService orden)
        {
            _context.OrdenService.Add(orden);
            await _context.SaveChangesAsync();
            return orden;
        }

        public async Task<bool> Actualizar(OrdenService orden)
        {
            _context.OrdenService.Update(orden);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(OrdenService orden)
        {
            _context.OrdenService.Remove(orden);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}