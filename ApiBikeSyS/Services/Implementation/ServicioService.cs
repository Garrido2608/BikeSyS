using ApiBikeSyS.DTOs.Servicio;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repository;
        private readonly IMapper _mapper;

        public ServicioService(IServicioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ServicioDTO>> ObtenerTodos()
        {
            var lista = await _repository.ObtenerTodos();
            return _mapper.Map<List<ServicioDTO>>(lista);
        }

        public async Task<ServicioDTO?> ObtenerPorId(int id)
        {
            var item = await _repository.ObtenerPorId(id);
            if (item == null) return null;
            return _mapper.Map<ServicioDTO>(item);
        }

        public async Task<List<ServicioDTO>> ObtenerPorOrden(int idOrdenService)
        {
            var lista = await _repository.ObtenerPorOrden(idOrdenService);
            return _mapper.Map<List<ServicioDTO>>(lista);
        }

        public async Task<ServicioDTO> Crear(CrearServicioDTO dto)
        {
            var entidad = _mapper.Map<Servicio>(dto);
            var creado = await _repository.Crear(entidad);
            return _mapper.Map<ServicioDTO>(creado);
        }

        public async Task<bool> Actualizar(int id, ActualizarServicioDTO dto)
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