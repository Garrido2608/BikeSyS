using ApiBikeSyS.DTOs.HistorialEstado;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBikeSyS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialesEstadoController : ControllerBase
    {
        private readonly IHistorialEstadoService _service;

        public HistorialesEstadoController(IHistorialEstadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<HistorialEstadoDTO>>> ObtenerTodos()
        {
            var lista = await _service.ObtenerTodos();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialEstadoDTO>> ObtenerPorId(int id)
        {
            var historial = await _service.ObtenerPorId(id);
            if (historial == null) return NotFound();
            return Ok(historial);
        }

        // Endpoint para ver el historial de estados de una Orden específica
        [HttpGet("orden/{idOrdenService}")]
        public async Task<ActionResult<List<HistorialEstadoDTO>>> ObtenerPorOrden(int idOrdenService)
        {
            var lista = await _service.ObtenerPorOrden(idOrdenService);
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearHistorialEstadoDTO dto)
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
        public async Task<ActionResult> Actualizar(int id, ActualizarHistorialEstadoDTO dto)
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