using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.Estado
{
    public class CrearEstadoDTO
    {
        [Required(ErrorMessage = "El nombre del estado es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;
    }
}