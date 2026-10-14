using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface ITipoServicioRepository
    {
        Task<List<TipoServicio>> ObtenerTodos();
        Task<TipoServicio?> ObtenerPorId(int id);
        Task<TipoServicio?> ObtenerPorNombre(string nombre);
        Task<TipoServicio> Crear(TipoServicio tipoServicio);
        Task<bool> Actualizar(TipoServicio tipoServicio);
        Task<bool> Eliminar(TipoServicio tipoServicio);
    }
}