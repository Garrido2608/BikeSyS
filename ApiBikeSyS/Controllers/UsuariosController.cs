using ApiBikeSyS.DTOs.Usuario;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiBikeSyS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IConfiguration _config;

        public UsuariosController(IUsuarioService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> ObtenerTodos()
        {
            var usuarios = await _service.ObtenerTodos();
            return Ok(usuarios);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> ObtenerPorId(int id)
        {
            var usuario = await _service.ObtenerPorId(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        // Bootstrap: el primer usuario se crea sin token; a partir de ahí hace falta estar autenticado.
        [AllowAnonymous]
        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(CrearUsuarioDTO dto)
        {
            if (await _service.HayUsuarios() && User.Identity?.IsAuthenticated != true)
            {
                return Unauthorized("Solo un usuario autenticado puede registrar nuevos usuarios.");
            }

            try
            {
                var usuario = await _service.Registrar(dto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDTO>> Login(LoginDTO dto)
        {
            var usuario = await _service.Login(dto.Email, dto.Clave);

            if (usuario == null)
            {
                return Unauthorized("Email o contraseña incorrectos.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials);

            return Ok(new TokenResponseDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Mensaje = "Login exitoso"
            });
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, ActualizarUsuarioDTO dto)
        {
            try
            {
                var resultado = await _service.Actualizar(id, dto);
                if (!resultado) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var resultado = await _service.Eliminar(id);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}