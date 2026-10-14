using ApiBikeSyS.DTOs.Usuario;
using ApiBikeSyS.Models;
using ApiBikeSyS.Repositories.Interfaces;
using ApiBikeSyS.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace ApiBikeSyS.Services.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Usuario> _hasher;

        // Los hashes de ASP.NET Core Identity (formato V3) siempre empiezan con este prefijo.
        // Lo que no lo tenga es una clave guardada en texto plano por la versión anterior.
        private const string PrefijoHash = "AQAAAA";

        public UsuarioService(IUsuarioRepository repository, IMapper mapper, IPasswordHasher<Usuario> hasher)
        {
            _repository = repository;
            _mapper = mapper;
            _hasher = hasher;
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
            usuario.Clave = _hasher.HashPassword(usuario, dto.Clave);
            usuario.Activo = true;

            var creado = await _repository.Crear(usuario);
            return _mapper.Map<UsuarioDTO>(creado);
        }

        public async Task<UsuarioDTO?> Login(string email, string clave)
        {
            var usuario = await _repository.ObtenerPorEmail(email);
            if (usuario == null || !usuario.Activo) return null;

            var rehashear = false;
            if (usuario.Clave.StartsWith(PrefijoHash, StringComparison.Ordinal))
            {
                var resultado = _hasher.VerifyHashedPassword(usuario, usuario.Clave, clave);
                if (resultado == PasswordVerificationResult.Failed) return null;
                rehashear = resultado == PasswordVerificationResult.SuccessRehashNeeded;
            }
            else
            {
                // Clave legada en texto plano: comparar en tiempo constante y migrarla al hash.
                var guardada = Encoding.UTF8.GetBytes(usuario.Clave);
                var ingresada = Encoding.UTF8.GetBytes(clave);
                if (!CryptographicOperations.FixedTimeEquals(guardada, ingresada)) return null;
                rehashear = true;
            }

            if (rehashear)
            {
                usuario.Clave = _hasher.HashPassword(usuario, clave);
                await _repository.Actualizar(usuario);
            }

            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<bool> HayUsuarios()
        {
            return await _repository.HayUsuarios();
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

            _mapper.Map(dto, usuario);
            if (!string.IsNullOrWhiteSpace(dto.Clave))
            {
                usuario.Clave = _hasher.HashPassword(usuario, dto.Clave);
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