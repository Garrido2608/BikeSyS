using ApiBikeSyS.DTOs.Provincia;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBikeSyS.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly IProvinciaService _service;

        public ProvinciasController(IProvinciaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProvinciaDTO>>> ObtenerTodos()
        {
            var provincias = await _service.ObtenerTodos();
            return Ok(provincias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProvinciaDTO>> ObtenerPorId(int id)
        {
            var provincia = await _service.ObtenerPorId(id);
            if (provincia == null) return NotFound();
            return Ok(provincia);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearProvinciaDTO dto)
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
        public async Task<ActionResult> Actualizar(int id, ActualizarProvinciaDTO dto)
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