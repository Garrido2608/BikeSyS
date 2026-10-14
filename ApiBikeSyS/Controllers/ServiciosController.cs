using ApiBikeSyS.DTOs.Servicio;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBikeSyS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IServicioService _service;

        public ServiciosController(IServicioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServicioDTO>>> ObtenerTodos()
        {
            var lista = await _service.ObtenerTodos();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServicioDTO>> ObtenerPorId(int id)
        {
            var item = await _service.ObtenerPorId(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // Endpoint para ver los servicios realizados en una Orden específica
        [HttpGet("orden/{idOrdenService}")]
        public async Task<ActionResult<List<ServicioDTO>>> ObtenerPorOrden(int idOrdenService)
        {
            var lista = await _service.ObtenerPorOrden(idOrdenService);
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearServicioDTO dto)
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
        public async Task<ActionResult> Actualizar(int id, ActualizarServicioDTO dto)
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