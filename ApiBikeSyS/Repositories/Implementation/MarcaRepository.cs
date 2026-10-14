using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly AppDbContext _context;

        public MarcaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Marca>> ObtenerTodos()
        {
            return await _context.Marca
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Marca?> ObtenerPorId(int id)
        {
            return await _context.Marca
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Marca?> ObtenerPorNombre(string nombre)
        {
            return await _context.Marca
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Nombre == nombre);
        }

        public async Task<Marca> Crear(Marca marca)
        {
            _context.Marca.Add(marca);
            await _context.SaveChangesAsync();
            return marca;
        }

        public async Task<bool> Actualizar(Marca marca)
        {
            _context.Marca.Update(marca);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(Marca marca)
        {
            _context.Marca.Remove(marca);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}