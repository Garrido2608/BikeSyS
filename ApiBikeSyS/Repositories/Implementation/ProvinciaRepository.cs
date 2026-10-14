using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class ProvinciaRepository : IProvinciaRepository
    {
        private readonly AppDbContext _context;

        public ProvinciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Provincia>> ObtenerTodos()
        {
            return await _context.Provincia
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Provincia?> ObtenerPorId(int id)
        {
            return await _context.Provincia
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Provincia?> ObtenerPorNombre(string nombre)
        {
            return await _context.Provincia
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Nombre == nombre);
        }

        public async Task<Provincia> Crear(Provincia provincia)
        {
            _context.Provincia.Add(provincia);
            await _context.SaveChangesAsync();
            return provincia;
        }

        public async Task<bool> Actualizar(Provincia provincia)
        {
            _context.Provincia.Update(provincia);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(Provincia provincia)
        {
            _context.Provincia.Remove(provincia);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}