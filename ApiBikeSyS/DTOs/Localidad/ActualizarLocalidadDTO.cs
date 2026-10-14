using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.Localidad
{
    public class ActualizarLocalidadDTO
    {
        [Required(ErrorMessage = "El nombre de la localidad es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La provincia es obligatoria")]
        public int IdProvincia { get; set; }
    }
}
