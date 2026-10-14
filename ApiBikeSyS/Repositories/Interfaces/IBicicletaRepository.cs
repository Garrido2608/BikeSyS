using ApiBikeSyS.Models;

namespace ApiBikeSyS.Repositories.Interfaces
{
    public interface IBicicletaRepository
    {
        Task<List<Bicicleta>> ObtenerTodos();
        Task<Bicicleta?> ObtenerPorId(int id);
        Task<List<Bicicleta>> ObtenerPorCliente(int idCliente);
        Task<Bicicleta> Crear(Bicicleta bicicleta);
        Task<bool> Actualizar(Bicicleta bicicleta);
        Task<bool> Eliminar(Bicicleta bicicleta);
    }
}