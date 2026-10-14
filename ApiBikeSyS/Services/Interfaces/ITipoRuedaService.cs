using ApiBikeSyS.DTOs.TipoRueda;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface ITipoRuedaService
    {
        Task<List<TipoRuedaDTO>> ObtenerTodos();
        Task<TipoRuedaDTO?> ObtenerPorId(int id);
        Task<TipoRuedaDTO> Crear(CrearTipoRuedaDTO dto);
        Task<bool> Actualizar(int id, ActualizarTipoRuedaDTO dto);
        Task<bool> Eliminar(int id);
    }
}