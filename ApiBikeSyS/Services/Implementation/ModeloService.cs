using ApiBikeSyS.DTOs.Modelo;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _repository;
        private readonly IMapper _mapper;

        public ModeloService(IModeloRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ModeloDTO>> ObtenerTodos()
        {
            var modelos = await _repository.ObtenerTodos();
            return _mapper.Map<List<ModeloDTO>>(modelos);
        }

        public async Task<ModeloDTO?> ObtenerPorId(int id)
        {
            var modelo = await _repository.ObtenerPorId(id);
            if (modelo == null) return null;
            return _mapper.Map<ModeloDTO>(modelo);
        }

        public async Task<ModeloDTO> Crear(CrearModeloDTO dto)
        {
            var existente = await _repository.ObtenerPorTipo(dto.TipoModelo);
            if (existente != null)
            {
                throw new Exception("Ya existe un modelo registrado con ese tipo.");
            }

            var modelo = _mapper.Map<Modelo>(dto);
            var creado = await _repository.Crear(modelo);
            return _mapper.Map<ModeloDTO>(creado);
        }

        public async Task<bool> Actualizar(int id, ActualizarModeloDTO dto)
        {
            var modelo = await _repository.ObtenerPorId(id);
            if (modelo == null) return false;

            var modeloTipo = await _repository.ObtenerPorTipo(dto.TipoModelo);
            if (modeloTipo != null && modeloTipo.Id != id)
            {
                throw new Exception("El tipo de modelo ya pertenece a otro registro.");
            }

            _mapper.Map(dto, modelo);
            return await _repository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            var modelo = await _repository.ObtenerPorId(id);
            if (modelo == null) return false;
            return await _repository.Eliminar(modelo);
        }
    }
}