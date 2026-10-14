using ApiBikeSyS.DTOs.Marca;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _repository;
        private readonly IMapper _mapper;

        public MarcaService(IMarcaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MarcaDTO>> ObtenerTodos()
        {
            var marcas = await _repository.ObtenerTodos();
            return _mapper.Map<List<MarcaDTO>>(marcas);
        }

        public async Task<MarcaDTO?> ObtenerPorId(int id)
        {
            var marca = await _repository.ObtenerPorId(id);
            if (marca == null) return null;
            return _mapper.Map<MarcaDTO>(marca);
        }

        public async Task<MarcaDTO> Crear(CrearMarcaDTO dto)
        {
            var existente = await _repository.ObtenerPorNombre(dto.Nombre);
            if (existente != null)
            {
                throw new Exception("Ya existe una marca registrada con ese nombre.");
            }

            var marca = _mapper.Map<Marca>(dto);
            var creada = await _repository.Crear(marca);
            return _mapper.Map<MarcaDTO>(creada);
        }

        public async Task<bool> Actualizar(int id, ActualizarMarcaDTO dto)
        {
            var marca = await _repository.ObtenerPorId(id);
            if (marca == null) return false;

            var marcaNombre = await _repository.ObtenerPorNombre(dto.Nombre);
            if (marcaNombre != null && marcaNombre.Id != id)
            {
                throw new Exception("El nombre ya pertenece a otra marca.");
            }

            _mapper.Map(dto, marca);
            return await _repository.Actualizar(marca);
        }

        public async Task<bool> Eliminar(int id)
        {
            var marca = await _repository.ObtenerPorId(id);
            if (marca == null) return false;
            return await _repository.Eliminar(marca);
        }
    }
}