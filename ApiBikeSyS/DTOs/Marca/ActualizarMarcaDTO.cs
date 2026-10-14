using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.Marca
{
    public class ActualizarMarcaDTO
    {
        [Required(ErrorMessage = "El nombre de la marca es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
    }
}