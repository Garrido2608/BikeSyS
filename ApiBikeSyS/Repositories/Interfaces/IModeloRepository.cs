using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface IModeloRepository
    {
        Task<List<Modelo>> ObtenerTodos();
        Task<Modelo?> ObtenerPorId(int id);
        Task<Modelo?> ObtenerPorTipo(string tipoModelo);
        Task<Modelo> Crear(Modelo modelo);
        Task<bool> Actualizar(Modelo modelo);
        Task<bool> Eliminar(Modelo modelo);
    }
}