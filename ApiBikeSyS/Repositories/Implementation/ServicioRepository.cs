using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly AppDbContext _context;

        public ServicioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servicio>> ObtenerTodos()
        {
            return await _context.Servicio
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Servicio?> ObtenerPorId(int id)
        {
            return await _context.Servicio
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Servicio>> ObtenerPorOrden(int idOrdenService)
        {
            return await _context.Servicio
                .AsNoTracking()
                .Where(s => s.IdOrdenService == idOrdenService)
                .ToListAsync();
        }

        public async Task<Servicio> Crear(Servicio servicio)
        {
            _context.Servicio.Add(servicio);
            await _context.SaveChangesAsync();
            return servicio;
        }

        public async Task<bool> Actualizar(Servicio servicio)
        {
            _context.Servicio.Update(servicio);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(Servicio servicio)
        {
            _context.Servicio.Remove(servicio);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}