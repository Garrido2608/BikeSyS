using ApiBikeSyS.DTOs.Marca;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface IMarcaService
    {
        Task<List<MarcaDTO>> ObtenerTodos();
        Task<MarcaDTO?> ObtenerPorId(int id);
        Task<MarcaDTO> Crear(CrearMarcaDTO dto);
        Task<bool> Actualizar(int id, ActualizarMarcaDTO dto);
        Task<bool> Eliminar(int id);
    }
}