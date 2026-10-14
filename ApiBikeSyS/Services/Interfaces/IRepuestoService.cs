using ApiBikeSyS.DTOs.Repuesto;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface IRepuestoService
    {
        Task<List<RepuestoDTO>> ObtenerTodos();
        Task<RepuestoDTO?> ObtenerPorId(int id);
        Task<RepuestoDTO> Crear(CrearRepuestoDTO dto);
        Task<bool> Actualizar(int id, ActualizarRepuestoDTO dto);
        Task<bool> Eliminar(int id);
    }
}