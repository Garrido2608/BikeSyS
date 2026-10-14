using ApiBikeSyS.DTOs.Modelo;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBikeSyS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly IModeloService _service;

        public ModelosController(IModeloService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ModeloDTO>>> ObtenerTodos()
        {
            var modelos = await _service.ObtenerTodos();
            return Ok(modelos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModeloDTO>> ObtenerPorId(int id)
        {
            var modelo = await _service.ObtenerPorId(id);
            if (modelo == null) return NotFound();
            return Ok(modelo);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearModeloDTO dto)
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
        public async Task<ActionResult> Actualizar(int id, ActualizarModeloDTO dto)
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