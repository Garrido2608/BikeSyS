using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface IMarcaRepository
    {
        Task<List<Marca>> ObtenerTodos();
        Task<Marca?> ObtenerPorId(int id);
        Task<Marca?> ObtenerPorNombre(string nombre);
        Task<Marca> Crear(Marca marca);
        Task<bool> Actualizar(Marca marca);
        Task<bool> Eliminar(Marca marca);
    }
}