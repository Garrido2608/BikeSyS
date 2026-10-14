using ApiBikeSyS.DTOs.Localidad;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class LocalidadService : ILocalidadService
    {
        private readonly ILocalidadRepository _repository;
        private readonly IMapper _mapper;

        public LocalidadService(ILocalidadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<LocalidadDTO>> ObtenerTodos()
        {
            var localidades = await _repository.ObtenerTodos();
            return _mapper.Map<List<LocalidadDTO>>(localidades);
        }

        public async Task<LocalidadDTO?> ObtenerPorId(int id)
        {
            var localidad = await _repository.ObtenerPorId(id);
            if (localidad == null) return null;
            return _mapper.Map<LocalidadDTO>(localidad);
        }

        public async Task<List<LocalidadDTO>> ObtenerPorProvincia(int idProvincia)
        {
            var localidades = await _repository.ObtenerPorProvincia(idProvincia);
            return _mapper.Map<List<LocalidadDTO>>(localidades);
        }

        public async Task<LocalidadDTO> Crear(CrearLocalidadDTO dto)
        {
            var localidad = _mapper.Map<Localidad>(dto);
            var creada = await _repository.Crear(localidad);
            return _mapper.Map<LocalidadDTO>(creada);
        }

        public async Task<bool> Actualizar(int id, ActualizarLocalidadDTO dto)
        {
            var localidad = await _repository.ObtenerPorId(id);
            if (localidad == null) return false;

            _mapper.Map(dto, localidad);
            return await _repository.Actualizar(localidad);
        }

        public async Task<bool> Eliminar(int id)
        {
            var localidad = await _repository.ObtenerPorId(id);
            if (localidad == null) return false;
            return await _repository.Eliminar(localidad);
        }
    }
}