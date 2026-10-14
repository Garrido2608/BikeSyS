using ApiBikeSyS.DTOs.Modelo;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface IModeloService
    {
        Task<List<ModeloDTO>> ObtenerTodos();
        Task<ModeloDTO?> ObtenerPorId(int id);
        Task<ModeloDTO> Crear(CrearModeloDTO dto);
        Task<bool> Actualizar(int id, ActualizarModeloDTO dto);
        Task<bool> Eliminar(int id);
    }
}