using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly AppDbContext _context;

        public ModeloRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Modelo>> ObtenerTodos()
        {
            return await _context.Modelo
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Modelo?> ObtenerPorId(int id)
        {
            return await _context.Modelo
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Modelo?> ObtenerPorTipo(string tipoModelo)
        {
            return await _context.Modelo
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TipoModelo == tipoModelo);
        }

        public async Task<Modelo> Crear(Modelo modelo)
        {
            _context.Modelo.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> Actualizar(Modelo modelo)
        {
            _context.Modelo.Update(modelo);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(Modelo modelo)
        {
            _context.Modelo.Remove(modelo);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}