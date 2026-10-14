using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface IEstadoRepository
    {
        Task<List<Estado>> ObtenerTodos();
        Task<Estado?> ObtenerPorId(int id);
        Task<Estado?> ObtenerPorNombre(string nombre);
        Task<Estado> Crear(Estado estado);
        Task<bool> Actualizar(Estado estado);
        Task<bool> Eliminar(Estado estado);
    }
}