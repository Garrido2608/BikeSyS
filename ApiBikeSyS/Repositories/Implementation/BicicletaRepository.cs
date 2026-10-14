using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class BicicletaRepository : IBicicletaRepository
    {
        private readonly AppDbContext _context;

        public BicicletaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bicicleta>> ObtenerTodos()
        {
            return await _context.Bicicleta
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Bicicleta?> ObtenerPorId(int id)
        {
            return await _context.Bicicleta
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Bicicleta>> ObtenerPorCliente(int idCliente)
        {
            return await _context.Bicicleta
                .AsNoTracking()
                .Where(b => b.IdCliente == idCliente)
                .ToListAsync();
        }

        public async Task<Bicicleta> Crear(Bicicleta bicicleta)
        {
            _context.Bicicleta.Add(bicicleta);
            await _context.SaveChangesAsync();
            return bicicleta;
        }

        public async Task<bool> Actualizar(Bicicleta bicicleta)
        {
            _context.Bicicleta.Update(bicicleta);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(Bicicleta bicicleta)
        {
            _context.Bicicleta.Remove(bicicleta);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}