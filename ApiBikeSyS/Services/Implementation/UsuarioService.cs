using ApiBikeSyS.DTOs.Usuario;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;

namespace ApiBikeSyS.Services.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDTO>> ObtenerTodos()
        {
            var usuarios = await _repository.ObtenerTodos();
            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        public async Task<UsuarioDTO?> ObtenerPorId(int id)
        {
            var usuario = await _repository.ObtenerPorId(id);
            if (usuario == null) return null;
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<UsuarioDTO> Registrar(CrearUsuarioDTO dto)
        {
            var existente = await _repository.ObtenerPorEmail(dto.Email);
            if (existente != null)
            {
                throw new Exception("Ya existe un usuario registrado con ese email.");
            }

            var usuario = _mapper.Map<Usuario>(dto);
            usuario.Activo = true;
            usuario.IdRol = 2;

            var creado = await _repository.Crear(usuario);
            return _mapper.Map<UsuarioDTO>(creado);
        }

        public async Task<UsuarioDTO?> Login(string email, string clave)
        {
            var usuario = await _repository.ObtenerPorEmailYClave(email, clave);
            if (usuario == null) return null;
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<bool> Actualizar(int id, ActualizarUsuarioDTO dto)
        {
            var usuario = await _repository.ObtenerPorId(id);
            if (usuario == null) return false;

            var usuarioEmail = await _repository.ObtenerPorEmail(dto.Email);
            if (usuarioEmail != null && usuarioEmail.Id != id)
            {
                throw new Exception("El email ya pertenece a otro usuario.");
            }

            int rolAnterior = usuario.IdRol;

            _mapper.Map(dto, usuario);

            // Si desde el front no enviaron IdRol conserva el rol que tenía
            if (dto.IdRol <= 0)
            {
                usuario.IdRol = rolAnterior;
            }

            return await _repository.Actualizar(usuario);
        }

        public async Task<bool> Eliminar(int id)
        {
            var usuario = await _repository.ObtenerPorId(id);
            if (usuario == null) return false;
            return await _repository.Eliminar(usuario);
        }
    }
}