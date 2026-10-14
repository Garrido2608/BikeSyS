using ApiBikeSyS.DTOs.Repuesto;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class RepuestoService : IRepuestoService
    {
        private readonly IRepuestoRepository _repository;
        private readonly IMapper _mapper;

        public RepuestoService(IRepuestoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RepuestoDTO>> ObtenerTodos()
        {
            var repuestos = await _repository.ObtenerTodos();
            return _mapper.Map<List<RepuestoDTO>>(repuestos);
        }

        public async Task<RepuestoDTO?> ObtenerPorId(int id)
        {
            var repuesto = await _repository.ObtenerPorId(id);
            if (repuesto == null) return null;
            return _mapper.Map<RepuestoDTO>(repuesto);
        }

        public async Task<RepuestoDTO> Crear(CrearRepuestoDTO dto)
        {
            var existente = await _repository.ObtenerPorNombre(dto.Nombre);
            if (existente != null)
            {
                throw new Exception("Ya existe un repuesto registrado con ese nombre.");
            }

            var repuesto = _mapper.Map<Repuesto>(dto);
            var creado = await _repository.Crear(repuesto);
            return _mapper.Map<RepuestoDTO>(creado);
        }

        public async Task<bool> Actualizar(int id, ActualizarRepuestoDTO dto)
        {
            var repuesto = await _repository.ObtenerPorId(id);
            if (repuesto == null) return false;

            var repuestoNombre = await _repository.ObtenerPorNombre(dto.Nombre);
            if (repuestoNombre != null && repuestoNombre.Id != id)
            {
                throw new Exception("El nombre ya pertenece a otro repuesto.");
            }

            _mapper.Map(dto, repuesto);
            return await _repository.Actualizar(repuesto);
        }

        public async Task<bool> Eliminar(int id)
        {
            var repuesto = await _repository.ObtenerPorId(id);
            if (repuesto == null) return false;
            return await _repository.Eliminar(repuesto);
        }
    }
}