using ApiBikeSyS.DTOs.Usuario;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> ObtenerTodos();
        Task<UsuarioDTO?> ObtenerPorId(int id);
        Task<UsuarioDTO> Registrar(CrearUsuarioDTO dto);
        Task<UsuarioDTO?> Login(string email, string clave);
        Task<bool> Actualizar(int id, ActualizarUsuarioDTO dto);
        Task<bool> Eliminar(int id);
    }
}