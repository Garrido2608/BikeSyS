using ApiBikeSyS.DTOs.HistorialEstado;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class HistorialEstadoService : IHistorialEstadoService
    {
        private readonly IHistorialEstadoRepository _repository;
        private readonly IMapper _mapper;

        public HistorialEstadoService(IHistorialEstadoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<HistorialEstadoDTO>> ObtenerTodos()
        {
            var lista = await _repository.ObtenerTodos();
            return _mapper.Map<List<HistorialEstadoDTO>>(lista);
        }

        public async Task<HistorialEstadoDTO?> ObtenerPorId(int id)
        {
            var historial = await _repository.ObtenerPorId(id);
            if (historial == null) return null;
            return _mapper.Map<HistorialEstadoDTO>(historial);
        }

        public async Task<List<HistorialEstadoDTO>> ObtenerPorOrden(int idOrdenService)
        {
            var lista = await _repository.ObtenerPorOrden(idOrdenService);
            return _mapper.Map<List<HistorialEstadoDTO>>(lista);
        }

        public async Task<HistorialEstadoDTO> Crear(CrearHistorialEstadoDTO dto)
        {
            var historial = _mapper.Map<HistorialEstado>(dto);
            if (historial.Fecha == default)
            {
                historial.Fecha = DateTime.Now;
            }

            var creado = await _repository.Crear(historial);
            return _mapper.Map<HistorialEstadoDTO>(creado);
        }

        public async Task<bool> Actualizar(int id, ActualizarHistorialEstadoDTO dto)
        {
            var historial = await _repository.ObtenerPorId(id);
            if (historial == null) return false;

            _mapper.Map(dto, historial);
            return await _repository.Actualizar(historial);
        }

        public async Task<bool> Eliminar(int id)
        {
            var historial = await _repository.ObtenerPorId(id);
            if (historial == null) return false;
            return await _repository.Eliminar(historial);
        }
    }
}