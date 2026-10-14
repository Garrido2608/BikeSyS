using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.RepuestoUsado
{
    public class ActualizarRepuestoUsadoDTO
    {
        [Required(ErrorMessage = "La orden de service es obligatoria")]
        public int IdOrdenService { get; set; }

        [Required(ErrorMessage = "El repuesto es obligatorio")]
        public int IdRepuesto { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        public decimal PrecioUnitario { get; set; }
    }
}