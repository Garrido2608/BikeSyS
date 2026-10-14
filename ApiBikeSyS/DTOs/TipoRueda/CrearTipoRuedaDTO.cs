using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.TipoRueda
{
    public class CrearTipoRuedaDTO
    {
        [Required(ErrorMessage = "El nombre del tipo de rueda (rodado) es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;
    }
}