using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface ITipoRuedaRepository
    {
        Task<List<TipoRueda>> ObtenerTodos();
        Task<TipoRueda?> ObtenerPorId(int id);
        Task<TipoRueda?> ObtenerPorNombre(string nombre);
        Task<TipoRueda> Crear(TipoRueda tipoRueda);
        Task<bool> Actualizar(TipoRueda tipoRueda);
        Task<bool> Eliminar(TipoRueda tipoRueda);
    }
}