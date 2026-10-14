using ApiBikeSyS.Data;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBikeSyS.Repositories.Implementation
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObtenerTodos()
        {
            return await _context.Usuario
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Usuario?> ObtenerPorId(int id)
        {
            return await _context.Usuario
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario?> ObtenerPorEmail(string email)
        {
            return await _context.Usuario
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario?> ObtenerPorEmailYClave(string email, string clave)
        {
            return await _context.Usuario
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email && u.Clave == clave && u.Activo);
        }

        public async Task<Usuario> Crear(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Actualizar(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(Usuario usuario)
        {
            _context.Usuario.Remove(usuario);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}