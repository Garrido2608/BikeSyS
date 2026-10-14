using ApiBikeSyS.DTOs.Bicicleta;

namespace ApiBikeSyS.Services.Interfaces
{
    public interface IBicicletaService
    {
        Task<List<BicicletaDTO>> ObtenerTodos();
        Task<BicicletaDTO?> ObtenerPorId(int id);
        Task<List<BicicletaDTO>> ObtenerPorCliente(int idCliente);
        Task<BicicletaDTO> Crear(CrearBicicletaDTO dto);
        Task<bool> Actualizar(int id, ActualizarBicicletaDTO dto);
        Task<bool> Eliminar(int id);
    }
}