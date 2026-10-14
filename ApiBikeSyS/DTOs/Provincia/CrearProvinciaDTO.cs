using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.Provincia
{
    public class CrearProvinciaDTO
    {
        [Required(ErrorMessage = "El nombre de la provincia es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
    }
}