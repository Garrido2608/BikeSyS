using ApiBikeSyS.DTOs.Bicicleta;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class BicicletaService : IBicicletaService
    {
        private readonly IBicicletaRepository _repository;
        private readonly IMapper _mapper;

        public BicicletaService(IBicicletaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BicicletaDTO>> ObtenerTodos()
        {
            var bicicletas = await _repository.ObtenerTodos();
            return _mapper.Map<List<BicicletaDTO>>(bicicletas);
        }

        public async Task<BicicletaDTO?> ObtenerPorId(int id)
        {
            var bicicleta = await _repository.ObtenerPorId(id);
            if (bicicleta == null) return null;
            return _mapper.Map<BicicletaDTO>(bicicleta);
        }

        public async Task<List<BicicletaDTO>> ObtenerPorCliente(int idCliente)
        {
            var bicicletas = await _repository.ObtenerPorCliente(idCliente);
            return _mapper.Map<List<BicicletaDTO>>(bicicletas);
        }

        public async Task<BicicletaDTO> Crear(CrearBicicletaDTO dto)
        {
            var bicicleta = _mapper.Map<Bicicleta>(dto);
            var creada = await _repository.Crear(bicicleta);
            return _mapper.Map<BicicletaDTO>(creada);
        }

        public async Task<bool> Actualizar(int id, ActualizarBicicletaDTO dto)
        {
            var bicicleta = await _repository.ObtenerPorId(id);
            if (bicicleta == null) return false;

            _mapper.Map(dto, bicicleta);
            return await _repository.Actualizar(bicicleta);
        }

        public async Task<bool> Eliminar(int id)
        {
            var bicicleta = await _repository.ObtenerPorId(id);
            if (bicicleta == null) return false;
            return await _repository.Eliminar(bicicleta);
        }
    }
}