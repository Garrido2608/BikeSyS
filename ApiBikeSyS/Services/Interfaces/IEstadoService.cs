using ApiBikeSyS.DTOs.Estado;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface IEstadoService
    {
        Task<List<EstadoDTO>> ObtenerTodos();
        Task<EstadoDTO?> ObtenerPorId(int id);
        Task<EstadoDTO> Crear(CrearEstadoDTO dto);
        Task<bool> Actualizar(int id, ActualizarEstadoDTO dto);
        Task<bool> Eliminar(int id);
    }
}