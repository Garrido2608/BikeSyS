using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly AppDbContext _context;

        public EstadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estado>> ObtenerTodos()
        {
            return await _context.Estado
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Estado?> ObtenerPorId(int id)
        {
            return await _context.Estado
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Estado?> ObtenerPorNombre(string nombre)
        {
            return await _context.Estado
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Nombre == nombre);
        }

        public async Task<Estado> Crear(Estado estado)
        {
            _context.Estado.Add(estado);
            await _context.SaveChangesAsync();
            return estado;
        }

        public async Task<bool> Actualizar(Estado estado)
        {
            _context.Estado.Update(estado);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(Estado estado)
        {
            _context.Estado.Remove(estado);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}
