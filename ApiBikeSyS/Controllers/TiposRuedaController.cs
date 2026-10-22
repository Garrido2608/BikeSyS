using ApiBikeSyS.DTOs.TipoRueda;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBikeSyS.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class TiposRuedaController : ControllerBase
    {
        private readonly ITipoRuedaService _service;

        public TiposRuedaController(ITipoRuedaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoRuedaDTO>>> ObtenerTodos()
        {
            var tipos = await _service.ObtenerTodos();
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoRuedaDTO>> ObtenerPorId(int id)
        {
            var tipo = await _service.ObtenerPorId(id);
            if (tipo == null) return NotFound();
            return Ok(tipo);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearTipoRuedaDTO dto)
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
        public async Task<ActionResult> Actualizar(int id, ActualizarTipoRuedaDTO dto)
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