using ApiBikeSyS.DTOs.Servicio;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface IServicioService
    {
        Task<List<ServicioDTO>> ObtenerTodos();
        Task<ServicioDTO?> ObtenerPorId(int id);
        Task<List<ServicioDTO>> ObtenerPorOrden(int idOrdenService);
        Task<ServicioDTO> Crear(CrearServicioDTO dto);
        Task<bool> Actualizar(int id, ActualizarServicioDTO dto);
        Task<bool> Eliminar(int id);
    }
}