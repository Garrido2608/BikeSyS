using ApiBikeSyS.DTOs.RepuestoUsado;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface IRepuestoUsadoService
    {
        Task<List<RepuestoUsadoDTO>> ObtenerTodos();
        Task<RepuestoUsadoDTO?> ObtenerPorId(int id);
        Task<List<RepuestoUsadoDTO>> ObtenerPorOrden(int idOrdenService);
        Task<RepuestoUsadoDTO> Crear(CrearRepuestoUsadoDTO dto);
        Task<bool> Actualizar(int id, ActualizarRepuestoUsadoDTO dto);
        Task<bool> Eliminar(int id);
    }
}