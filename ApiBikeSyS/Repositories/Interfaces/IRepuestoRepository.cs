using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface IRepuestoRepository
    {
        Task<List<Repuesto>> ObtenerTodos();
        Task<Repuesto?> ObtenerPorId(int id);
        Task<Repuesto?> ObtenerPorNombre(string nombre);
        Task<Repuesto> Crear(Repuesto repuesto);
        Task<bool> Actualizar(Repuesto repuesto);
        Task<bool> Eliminar(Repuesto repuesto);
    }
}