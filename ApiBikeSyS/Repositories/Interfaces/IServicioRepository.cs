using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface IServicioRepository
    {
        Task<List<Servicio>> ObtenerTodos();
        Task<Servicio?> ObtenerPorId(int id);
        Task<List<Servicio>> ObtenerPorOrden(int idOrdenService);
        Task<Servicio> Crear(Servicio servicio);
        Task<bool> Actualizar(Servicio servicio);
        Task<bool> Eliminar(Servicio servicio);
    }
}