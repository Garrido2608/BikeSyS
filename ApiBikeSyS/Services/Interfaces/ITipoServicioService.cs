using ApiBikeSyS.DTOs.TipoServicio;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface ITipoServicioService
    {
        Task<List<TipoServicioDTO>> ObtenerTodos();
        Task<TipoServicioDTO?> ObtenerPorId(int id);
        Task<TipoServicioDTO> Crear(CrearTipoServicioDTO dto);
        Task<bool> Actualizar(int id, ActualizarTipoServicioDTO dto);
        Task<bool> Eliminar(int id);
    }
}