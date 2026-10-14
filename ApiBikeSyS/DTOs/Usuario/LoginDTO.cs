using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.Usuario
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La clave es obligatoria")]
        public string Clave { get; set; } = string.Empty;
    }
}