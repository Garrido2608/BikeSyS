using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface IOrdenServiceRepository
    {
        Task<List<OrdenService>> ObtenerTodos();
        Task<OrdenService?> ObtenerPorId(int id);
        Task<OrdenService> Crear(OrdenService orden);
        Task<bool> Actualizar(OrdenService orden);
        Task<bool> Eliminar(OrdenService orden);
    }
}