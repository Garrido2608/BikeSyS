using ApiBikeSyS.DTOs.OrdenService;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBikeSyS.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesServiceController : ControllerBase
    {
        private readonly IOrdenServiceService _service;

        public OrdenesServiceController(IOrdenServiceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrdenServiceDTO>>> ObtenerTodos()
        {
            var ordenes = await _service.ObtenerTodos();
            return Ok(ordenes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenServiceDTO>> ObtenerPorId(int id)
        {
            var orden = await _service.ObtenerPorId(id);
            if (orden == null) return NotFound();
            return Ok(orden);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearOrdenServiceDTO dto)
        {
            try
            {
                var orden = await _service.Crear(dto);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = orden.Id }, orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, ActualizarOrdenServiceDTO dto)
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