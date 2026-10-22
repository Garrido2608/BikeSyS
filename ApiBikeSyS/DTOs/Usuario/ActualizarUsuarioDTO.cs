using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.Usuario
{
    public class ActualizarUsuarioDTO
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
        public int IdRol { get; set; }

    }
}