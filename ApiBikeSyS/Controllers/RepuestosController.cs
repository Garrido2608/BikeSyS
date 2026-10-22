using ApiBikeSyS.DTOs.Repuesto;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBikeSyS.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RepuestosController : ControllerBase
    {
        private readonly IRepuestoService _service;

        public RepuestosController(IRepuestoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<RepuestoDTO>>> ObtenerTodos()
        {
            var repuestos = await _service.ObtenerTodos();
            return Ok(repuestos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepuestoDTO>> ObtenerPorId(int id)
        {
            var repuesto = await _service.ObtenerPorId(id);
            if (repuesto == null) return NotFound();
            return Ok(repuesto);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearRepuestoDTO dto)
        {
            try
            {
                var creado = await _service.Crear(dto);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, ActualizarRepuestoDTO dto)
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