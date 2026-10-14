using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ObtenerTodos();
        Task<Cliente?> ObtenerPorId(int id);
        Task<Cliente?> ObtenerPorDni(string dni);
        Task<Cliente> Crear(Cliente cliente);
        Task<bool> Actualizar(Cliente cliente);
        Task<bool> Eliminar(Cliente cliente);
    }
}