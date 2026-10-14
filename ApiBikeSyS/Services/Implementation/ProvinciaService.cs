using ApiBikeSyS.DTOs.Provincia;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class ProvinciaService : IProvinciaService
    {
        private readonly IProvinciaRepository _repository;
        private readonly IMapper _mapper;

        public ProvinciaService(IProvinciaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProvinciaDTO>> ObtenerTodos()
        {
            var provincias = await _repository.ObtenerTodos();
            return _mapper.Map<List<ProvinciaDTO>>(provincias);
        }

        public async Task<ProvinciaDTO?> ObtenerPorId(int id)
        {
            var provincia = await _repository.ObtenerPorId(id);
            if (provincia == null) return null;
            return _mapper.Map<ProvinciaDTO>(provincia);
        }

        public async Task<ProvinciaDTO> Crear(CrearProvinciaDTO dto)
        {
            var existente = await _repository.ObtenerPorNombre(dto.Nombre);
            if (existente != null)
            {
                throw new Exception("Ya existe una provincia registrada con ese nombre.");
            }

            var provincia = _mapper.Map<Provincia>(dto);
            var creada = await _repository.Crear(provincia);
            return _mapper.Map<ProvinciaDTO>(creada);
        }

        public async Task<bool> Actualizar(int id, ActualizarProvinciaDTO dto)
        {
            var provincia = await _repository.ObtenerPorId(id);
            if (provincia == null) return false;

            var provNombre = await _repository.ObtenerPorNombre(dto.Nombre);
            if (provNombre != null && provNombre.Id != id)
            {
                throw new Exception("El nombre ya pertenece a otra provincia.");
            }

            _mapper.Map(dto, provincia);
            return await _repository.Actualizar(provincia);
        }

        public async Task<bool> Eliminar(int id)
        {
            var provincia = await _repository.ObtenerPorId(id);
            if (provincia == null) return false;
            return await _repository.Eliminar(provincia);
        }
    }
}