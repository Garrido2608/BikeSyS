using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface IRepuestoUsadoRepository
    {
        Task<List<RepuestoUsado>> ObtenerTodos();
        Task<RepuestoUsado?> ObtenerPorId(int id);
        Task<List<RepuestoUsado>> ObtenerPorOrden(int idOrdenService);
        Task<RepuestoUsado> Crear(RepuestoUsado repuestoUsado);
        Task<bool> Actualizar(RepuestoUsado repuestoUsado);
        Task<bool> Eliminar(RepuestoUsado repuestoUsado);
    }
}