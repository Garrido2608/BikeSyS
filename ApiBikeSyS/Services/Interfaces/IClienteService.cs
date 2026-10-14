using ApiBikeSyS.DTOs;
using ApiBikeSyS.DTOs.Cliente;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClienteDTO>> ObtenerTodos();
        Task<ClienteDTO?> ObtenerPorId(int id);
        Task<ClienteDTO> Crear(CrearClienteDTO dto);
        Task<bool> Actualizar(int id, ActualizarClienteDTO dto);
        Task<bool> Eliminar(int id);
    }
}