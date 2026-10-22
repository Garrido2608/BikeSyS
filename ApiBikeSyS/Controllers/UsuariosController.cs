using ApiBikeSyS.DTOs.Usuario;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiBikeSyS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        // [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> ObtenerTodos()
        {
            var usuarios = await _service.ObtenerTodos();
            return Ok(usuarios);
        }

        // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> ObtenerPorId(int id)
        {
            var usuario = await _service.ObtenerPorId(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(CrearUsuarioDTO dto)
        {
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
        public async Task<ActionResult> Login(LoginDTO dto)
        {
            var usuario = await _service.Login(dto.Email, dto.Clave);

            if (usuario == null)
            {
                return Unauthorized("Email o contraseña incorrectos.");
            }

          
            return Ok(new
            {
                Mensaje = "Login exitoso",
                Usuario = usuario
            });
        }

        // [Authorize]
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

        // [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var resultado = await _service.Eliminar(id);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}