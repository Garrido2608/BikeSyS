using ApiBikeSyS.DTOs.OrdenService;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class OrdenServiceService : IOrdenServiceService
    {
        private readonly IOrdenServiceRepository _repository;
        private readonly IHistorialEstadoRepository _historialRepository;
        private readonly IMapper _mapper;

        public OrdenServiceService(
            IOrdenServiceRepository repository,
            IHistorialEstadoRepository historialRepository,
            IMapper mapper)
        {
            _repository = repository;
            _historialRepository = historialRepository;
            _mapper = mapper;
        }

        public async Task<List<OrdenServiceDTO>> ObtenerTodos()
        {
            var ordenes = await _repository.ObtenerTodos();
            return _mapper.Map<List<OrdenServiceDTO>>(ordenes);
        }

        public async Task<OrdenServiceDTO?> ObtenerPorId(int id)
        {
            var orden = await _repository.ObtenerPorId(id);
            if (orden == null) return null;
            return _mapper.Map<OrdenServiceDTO>(orden);
        }

        public async Task<OrdenServiceDTO> Crear(CrearOrdenServiceDTO dto)
        {
            var orden = _mapper.Map<OrdenService>(dto);
            if (orden.FechaRecepcion == default)
            {
                orden.FechaRecepcion = DateTime.Now;
            }

            var ordenCreada = await _repository.Crear(orden);

            // Regla de negocio: Registrar automáticamente el Estado Inicial (IdEstado = 1)
            var estadoInicial = new HistorialEstado
            {
                IdOrdenService = ordenCreada.Id,
                IdEstado = 1,
                Fecha = DateTime.Now
            };
            await _historialRepository.Crear(estadoInicial);

            return _mapper.Map<OrdenServiceDTO>(ordenCreada);
        }

        public async Task<bool> Actualizar(int id, ActualizarOrdenServiceDTO dto)
        {
            var orden = await _repository.ObtenerPorId(id);
            if (orden == null) return false;

            _mapper.Map(dto, orden);
            return await _repository.Actualizar(orden);
        }

        public async Task<bool> Eliminar(int id)
        {
            var orden = await _repository.ObtenerPorId(id);
            if (orden == null) return false;
            return await _repository.Eliminar(orden);
        }
    }
}