using ApiBikeSyS.DTOs.Estado;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _repository;
        private readonly IMapper _mapper;

        public EstadoService(IEstadoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EstadoDTO>> ObtenerTodos()
        {
            var estados = await _repository.ObtenerTodos();
            return _mapper.Map<List<EstadoDTO>>(estados);
        }

        public async Task<EstadoDTO?> ObtenerPorId(int id)
        {
            var estado = await _repository.ObtenerPorId(id);
            if (estado == null) return null;
            return _mapper.Map<EstadoDTO>(estado);
        }

        public async Task<EstadoDTO> Crear(CrearEstadoDTO dto)
        {
            var existente = await _repository.ObtenerPorNombre(dto.Nombre);
            if (existente != null)
            {
                throw new Exception("Ya existe un estado con ese nombre.");
            }

            var estado = _mapper.Map<Estado>(dto);
            var creado = await _repository.Crear(estado);
            return _mapper.Map<EstadoDTO>(creado);
        }

        public async Task<bool> Actualizar(int id, ActualizarEstadoDTO dto)
        {
            var estado = await _repository.ObtenerPorId(id);
            if (estado == null) return false;

            var estadoNombre = await _repository.ObtenerPorNombre(dto.Nombre);
            if (estadoNombre != null && estadoNombre.Id != id)
            {
                throw new Exception("El nombre ya pertenece a otro estado.");
            }

            _mapper.Map(dto, estado);
            return await _repository.Actualizar(estado);
        }

        public async Task<bool> Eliminar(int id)
        {
            var estado = await _repository.ObtenerPorId(id);
            if (estado == null) return false;
            return await _repository.Eliminar(estado);
        }
    }
}