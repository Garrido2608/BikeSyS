using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.Modelo
{
    public class CrearModeloDTO
    {
        [Required(ErrorMessage = "El tipo de modelo es obligatorio")]
        [StringLength(100, ErrorMessage = "El tipo de modelo no puede superar los 100 caracteres")]
        public string TipoModelo { get; set; } = string.Empty;
    }
}