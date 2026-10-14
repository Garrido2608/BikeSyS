using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.RepuestoUsado
{
    public class CrearRepuestoUsadoDTO
    {
        [Required]
        public int IdOrdenService { get; set; }

        [Required]
        public int IdRepuesto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }
    }
}