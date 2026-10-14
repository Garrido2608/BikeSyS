using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface IHistorialEstadoRepository
    {
        Task<List<HistorialEstado>> ObtenerTodos();
        Task<HistorialEstado?> ObtenerPorId(int id);
        Task<List<HistorialEstado>> ObtenerPorOrden(int idOrdenService);
        Task<HistorialEstado> Crear(HistorialEstado historial);
        Task<bool> Actualizar(HistorialEstado historial);
        Task<bool> Eliminar(HistorialEstado historial);
    }
}