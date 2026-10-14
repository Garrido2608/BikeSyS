using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.Usuario
{
    public class ActualizarUsuarioDTO
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        // Opcional: si no se envía, la clave actual no cambia.
        [StringLength(255, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 255 caracteres")]
        public string? Clave { get; set; }

        public bool Activo { get; set; } = true;
    }
}