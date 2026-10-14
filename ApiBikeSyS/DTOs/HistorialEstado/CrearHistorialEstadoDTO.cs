using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.HistorialEstado
{
    public class CrearHistorialEstadoDTO
    {
        [Required(ErrorMessage = "La orden de service es obligatoria")]
        public int IdOrdenService { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public int IdEstado { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}