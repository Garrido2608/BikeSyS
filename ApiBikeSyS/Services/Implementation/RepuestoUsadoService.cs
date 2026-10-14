using ApiBikeSyS.DTOs.RepuestoUsado;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class RepuestoUsadoService : IRepuestoUsadoService
    {
        private readonly IRepuestoUsadoRepository _repository;
        private readonly IRepuestoRepository _repuestoRepository;
        private readonly IMapper _mapper;

        public RepuestoUsadoService(
            IRepuestoUsadoRepository repository,
            IRepuestoRepository repuestoRepository,
            IMapper mapper)
        {
            _repository = repository;
            _repuestoRepository = repuestoRepository;
            _mapper = mapper;
        }

        public async Task<List<RepuestoUsadoDTO>> ObtenerTodos()
        {
            var lista = await _repository.ObtenerTodos();
            return _mapper.Map<List<RepuestoUsadoDTO>>(lista);
        }

        public async Task<RepuestoUsadoDTO?> ObtenerPorId(int id)
        {
            var item = await _repository.ObtenerPorId(id);
            if (item == null) return null;
            return _mapper.Map<RepuestoUsadoDTO>(item);
        }

        public async Task<List<RepuestoUsadoDTO>> ObtenerPorOrden(int idOrdenService)
        {
            var lista = await _repository.ObtenerPorOrden(idOrdenService);
            return _mapper.Map<List<RepuestoUsadoDTO>>(lista);
        }

        public async Task<RepuestoUsadoDTO> Crear(CrearRepuestoUsadoDTO dto)
        {
            // Validar existencia y descontar Stock automáticamente
            var repuesto = await _repuestoRepository.ObtenerPorId(dto.IdRepuesto);
            if (repuesto == null)
            {
                throw new Exception("El repuesto seleccionado no existe.");
            }

            if (repuesto.Stock < dto.Cantidad)
            {
                throw new Exception($"Stock insuficiente para '{repuesto.Nombre}'. Disponible: {repuesto.Stock}.");
            }

            repuesto.Stock -= dto.Cantidad;
            await _repuestoRepository.Actualizar(repuesto);

            var entidad = _mapper.Map<RepuestoUsado>(dto);
            var creado = await _repository.Crear(entidad);
            return _mapper.Map<RepuestoUsadoDTO>(creado);
        }

        public async Task<bool> Actualizar(int id, ActualizarRepuestoUsadoDTO dto)
        {
            var item = await _repository.ObtenerPorId(id);
            if (item == null) return false;

            _mapper.Map(dto, item);
            return await _repository.Actualizar(item);
        }

        public async Task<bool> Eliminar(int id)
        {
            var item = await _repository.ObtenerPorId(id);
            if (item == null) return false;
            return await _repository.Eliminar(item);
        }
    }
}