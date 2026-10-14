using ApiBikeSyS.DTOs.RepuestoUsado;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBikeSyS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RepuestosUsadoController : ControllerBase
    {
        private readonly IRepuestoUsadoService _service;

        public RepuestosUsadoController(IRepuestoUsadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<RepuestoUsadoDTO>>> ObtenerTodos()
        {
            var lista = await _service.ObtenerTodos();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepuestoUsadoDTO>> ObtenerPorId(int id)
        {
            var item = await _service.ObtenerPorId(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // Endpoint para ver los repuestos usados en una Orden específica
        [HttpGet("orden/{idOrdenService}")]
        public async Task<ActionResult<List<RepuestoUsadoDTO>>> ObtenerPorOrden(int idOrdenService)
        {
            var lista = await _service.ObtenerPorOrden(idOrdenService);
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearRepuestoUsadoDTO dto)
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
        public async Task<ActionResult> Actualizar(int id, ActualizarRepuestoUsadoDTO dto)
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