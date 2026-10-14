using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface IProvinciaRepository
    {
        Task<List<Provincia>> ObtenerTodos();
        Task<Provincia?> ObtenerPorId(int id);
        Task<Provincia?> ObtenerPorNombre(string nombre);
        Task<Provincia> Crear(Provincia provincia);
        Task<bool> Actualizar(Provincia provincia);
        Task<bool> Eliminar(Provincia provincia);
    }
}
