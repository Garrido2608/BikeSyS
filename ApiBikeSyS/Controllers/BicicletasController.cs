using ApiBikeSyS.DTOs.Bicicleta;
using ApiBikeSyS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBikeSyS.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class BicicletasController : ControllerBase
    {
        private readonly IBicicletaService _service;

        public BicicletasController(IBicicletaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<BicicletaDTO>>> ObtenerTodos()
        {
            var bicicletas = await _service.ObtenerTodos();
            return Ok(bicicletas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BicicletaDTO>> ObtenerPorId(int id)
        {
            var bicicleta = await _service.ObtenerPorId(id);
            if (bicicleta == null) return NotFound();
            return Ok(bicicleta);
        }

        
        // GET: api/Bicicletas/cliente/5
        [HttpGet("cliente/{idCliente}")]
        public async Task<ActionResult<List<BicicletaDTO>>> ObtenerPorCliente(int idCliente)
        {
            var bicicletas = await _service.ObtenerPorCliente(idCliente);
            return Ok(bicicletas);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearBicicletaDTO dto)
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
        public async Task<ActionResult> Actualizar(int id, ActualizarBicicletaDTO dto)
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