using ApiBikeSyS.DTOs.TipoRueda;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Implementation;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class TipoRuedaService : ITipoRuedaService
    {
        private readonly ITipoRuedaRepository _repository;
        private readonly IMapper _mapper;

        public TipoRuedaService(ITipoRuedaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TipoRuedaDTO>> ObtenerTodos()
        {
            var tipos = await _repository.ObtenerTodos();
            return _mapper.Map<List<TipoRuedaDTO>>(tipos);
        }

        public async Task<TipoRuedaDTO?> ObtenerPorId(int id)
        {
            var tipo = await _repository.ObtenerPorId(id);
            if (tipo == null) return null;
            return _mapper.Map<TipoRuedaDTO>(tipo);
        }

        public async Task<TipoRuedaDTO> Crear(CrearTipoRuedaDTO dto)
        {
            var existente = await _repository.ObtenerPorNombre(dto.Nombre);
            if (existente != null)
            {
                throw new Exception("Ya existe un tipo de rueda registrado con ese nombre.");
            }

            var tipo = _mapper.Map<TipoRueda>(dto);
            var creado = await _repository.Crear(tipo);
            return _mapper.Map<TipoRuedaDTO>(creado);
        }

        public async Task<bool> Actualizar(int id, ActualizarTipoRuedaDTO dto)
        {
            var tipo = await _repository.ObtenerPorId(id);
            if (tipo == null) return false;

            var tipoNombre = await _repository.ObtenerPorNombre(dto.Nombre);
            if (tipoNombre != null && tipoNombre.Id != id)
            {
                throw new Exception("El nombre ya pertenece a otro tipo de rueda.");
            }

            _mapper.Map(dto, tipo);
            return await _repository.Actualizar(tipo);
        }

        public async Task<bool> Eliminar(int id)
        {
            var tipo = await _repository.ObtenerPorId(id);
            if (tipo == null) return false;
            return await _repository.Eliminar(tipo);
        }
    }
}