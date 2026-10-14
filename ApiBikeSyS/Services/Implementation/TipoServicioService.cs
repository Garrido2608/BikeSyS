using ApiBikeSyS.DTOs.TipoServicio;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class TipoServicioService : ITipoServicioService
    {
        private readonly ITipoServicioRepository _repository;
        private readonly IMapper _mapper;

        public TipoServicioService(ITipoServicioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TipoServicioDTO>> ObtenerTodos()
        {
            var tipos = await _repository.ObtenerTodos();
            return _mapper.Map<List<TipoServicioDTO>>(tipos);
        }

        public async Task<TipoServicioDTO?> ObtenerPorId(int id)
        {
            var tipo = await _repository.ObtenerPorId(id);
            if (tipo == null) return null;
            return _mapper.Map<TipoServicioDTO>(tipo);
        }

        public async Task<TipoServicioDTO> Crear(CrearTipoServicioDTO dto)
        {
            var existente = await _repository.ObtenerPorNombre(dto.Nombre);
            if (existente != null)
            {
                throw new Exception("Ya existe un tipo de servicio con ese nombre.");
            }

            var tipo = _mapper.Map<TipoServicio>(dto);
            var creado = await _repository.Crear(tipo);
            return _mapper.Map<TipoServicioDTO>(creado);
        }

        public async Task<bool> Actualizar(int id, ActualizarTipoServicioDTO dto)
        {
            var tipo = await _repository.ObtenerPorId(id);
            if (tipo == null) return false;

            var tipoNombre = await _repository.ObtenerPorNombre(dto.Nombre);
            if (tipoNombre != null && tipoNombre.Id != id)
            {
                throw new Exception("El nombre ya pertenece a otro tipo de servicio.");
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