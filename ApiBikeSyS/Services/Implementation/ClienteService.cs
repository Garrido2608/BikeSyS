using ApiBikeSyS.DTOs;
using ApiBikeSyS.DTOs.Cliente;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ClienteDTO>> ObtenerTodos()
        {
            var clientes = await _repository.ObtenerTodos();
            return _mapper.Map<List<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO?> ObtenerPorId(int id)
        {
            var cliente = await _repository.ObtenerPorId(id);
            if (cliente == null) return null;
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<ClienteDTO> Crear(CrearClienteDTO dto)
        {
            if (!string.IsNullOrEmpty(dto.DNI))
            {
                var existente = await _repository.ObtenerPorDni(dto.DNI);
                if (existente != null)
                {
                    throw new Exception("Ya existe un cliente registrado con este DNI.");
                }
            }

            var cliente = _mapper.Map<Cliente>(dto);
            var clienteCreado = await _repository.Crear(cliente);
            return _mapper.Map<ClienteDTO>(clienteCreado);
        }

        public async Task<bool> Actualizar(int id, ActualizarClienteDTO dto)
        {
            var cliente = await _repository.ObtenerPorId(id);
            if (cliente == null) return false;

            if (!string.IsNullOrEmpty(dto.DNI))
            {
                var existente = await _repository.ObtenerPorDni(dto.DNI);
                if (existente != null && existente.Id != id)
                {
                    throw new Exception("El DNI ya pertenece a otro cliente.");
                }
            }

            _mapper.Map(dto, cliente);
            return await _repository.Actualizar(cliente);
        }
        
        public async Task<bool> Eliminar(int id)
        {
            var cliente = await _repository.ObtenerPorId(id);
            if (cliente == null) return false;
            return await _repository.Eliminar(cliente);
        }
    }
}