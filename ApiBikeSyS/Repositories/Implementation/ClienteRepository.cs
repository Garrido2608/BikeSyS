using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> ObtenerTodos()
        {
            return await _context.Cliente
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente?> ObtenerPorId(int id)
        {
            return await _context.Cliente
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente?> ObtenerPorDni(string dni)
        {
            return await _context.Cliente
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Dni == dni);
        }

        public async Task<Cliente> Crear(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> Actualizar(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(Cliente cliente)
        {
            _context.Cliente.Remove(cliente);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}