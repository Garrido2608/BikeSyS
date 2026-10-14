using ApiBikeSyS.DTOs.HistorialEstado;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface IHistorialEstadoService
    {
        Task<List<HistorialEstadoDTO>> ObtenerTodos();
        Task<HistorialEstadoDTO?> ObtenerPorId(int id);
        Task<List<HistorialEstadoDTO>> ObtenerPorOrden(int idOrdenService);
        Task<HistorialEstadoDTO> Crear(CrearHistorialEstadoDTO dto);
        Task<bool> Actualizar(int id, ActualizarHistorialEstadoDTO dto);
        Task<bool> Eliminar(int id);
    }
}