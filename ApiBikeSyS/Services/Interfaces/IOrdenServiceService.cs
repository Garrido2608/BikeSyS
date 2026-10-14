using ApiBikeSyS.DTOs.OrdenService;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface IOrdenServiceService
    {
        Task<List<OrdenServiceDTO>> ObtenerTodos();
        Task<OrdenServiceDTO?> ObtenerPorId(int id);
        Task<OrdenServiceDTO> Crear(CrearOrdenServiceDTO dto);
        Task<bool> Actualizar(int id, ActualizarOrdenServiceDTO dto);
        Task<bool> Eliminar(int id);
    }
}