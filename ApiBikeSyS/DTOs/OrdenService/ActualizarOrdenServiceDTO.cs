using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.OrdenService
{
    public class ActualizarOrdenServiceDTO
    {
        [Required(ErrorMessage = "La bicicleta es obligatoria")]
        public int IdBicicleta { get; set; }

        [Required(ErrorMessage = "La fecha de recepción es obligatoria")]
        public DateTime FechaRecepcion { get; set; }

        [Required(ErrorMessage = "El motivo es obligatorio")]
        [StringLength(255, ErrorMessage = "El motivo no puede superar los 255 caracteres")]
        public string Motivo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El total general es obligatorio")]
        public decimal TotalGeneral { get; set; }
    }
}