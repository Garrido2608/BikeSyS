using ApiBikeSyS.DTOs.Localidad;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBikeSyS.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadesController : ControllerBase
    {
        private readonly ILocalidadService _service;

        public LocalidadesController(ILocalidadService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<LocalidadDTO>>> ObtenerTodos()
        {
            var localidades = await _service.ObtenerTodos();
            return Ok(localidades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocalidadDTO>> ObtenerPorId(int id)
        {
            var localidad = await _service.ObtenerPorId(id);
            if (localidad == null) return NotFound();
            return Ok(localidad);
        }

        // para el combo en cascada del Frontend (Provincia -> Localidad)
        [HttpGet("provincia/{idProvincia}")]
        public async Task<ActionResult<List<LocalidadDTO>>> ObtenerPorProvincia(int idProvincia)
        {
            var localidades = await _service.ObtenerPorProvincia(idProvincia);
            return Ok(localidades);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearLocalidadDTO dto)
        {
            try
            {
                var creada = await _service.Crear(dto);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = creada.Id }, creada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, ActualizarLocalidadDTO dto)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var resultado = await _service.Eliminar(id);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}