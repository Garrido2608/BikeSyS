using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface ILocalidadRepository
    {
        Task<List<Localidad>> ObtenerTodos();
        Task<Localidad?> ObtenerPorId(int id);
        Task<List<Localidad>> ObtenerPorProvincia(int idProvincia);
        Task<Localidad> Crear(Localidad localidad);
        Task<bool> Actualizar(Localidad localidad);
        Task<bool> Eliminar(Localidad localidad);
    }
}