using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.Servicio
{
    public class ActualizarServicioDTO
    {
        [Required(ErrorMessage = "La orden de service es obligatoria")]
        public int IdOrdenService { get; set; }

        [Required(ErrorMessage = "El tipo de servicio es obligatorio")]
        public int IdTipoServicio { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1")]
        public int Cantidad { get; set; } = 1;

        [Required(ErrorMessage = "El costo es obligatorio")]
        public decimal Costo { get; set; }
    }
}