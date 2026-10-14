using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.TipoServicio
{
    public class ActualizarTipoServicioDTO
    {
        [Required(ErrorMessage = "El nombre del tipo de servicio es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }
    }
}