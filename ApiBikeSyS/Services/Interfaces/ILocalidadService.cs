using ApiBikeSyS.DTOs.Localidad;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface ILocalidadService
    {
        Task<List<LocalidadDTO>> ObtenerTodos();
        Task<LocalidadDTO?> ObtenerPorId(int id);
        Task<List<LocalidadDTO>> ObtenerPorProvincia(int idProvincia);
        Task<LocalidadDTO> Crear(CrearLocalidadDTO dto);
        Task<bool> Actualizar(int id, ActualizarLocalidadDTO dto);
        Task<bool> Eliminar(int id);
    }
}