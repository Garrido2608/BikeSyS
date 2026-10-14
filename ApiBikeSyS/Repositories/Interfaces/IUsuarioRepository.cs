using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ObtenerTodos();
        Task<Usuario?> ObtenerPorId(int id);
        Task<Usuario?> ObtenerPorEmail(string email);
        Task<Usuario?> ObtenerPorEmailYClave(string email, string clave);
        Task<Usuario> Crear(Usuario usuario);
        Task<bool> Actualizar(Usuario usuario);
        Task<bool> Eliminar(Usuario usuario);
    }
}