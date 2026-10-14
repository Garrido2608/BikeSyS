using ApiBikeSyS.DTOs.Provincia;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface IProvinciaService
    {
        Task<List<ProvinciaDTO>> ObtenerTodos();
        Task<ProvinciaDTO?> ObtenerPorId(int id);
        Task<ProvinciaDTO> Crear(CrearProvinciaDTO dto);
        Task<bool> Actualizar(int id, ActualizarProvinciaDTO dto);
        Task<bool> Eliminar(int id);
    }
}