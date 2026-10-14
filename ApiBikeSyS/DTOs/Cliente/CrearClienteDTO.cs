using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.Cliente
{
    public class CrearClienteDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [StringLength(20)]
        public string? DNI { get; set; }

        [StringLength(150)]
        public string? Calle { get; set; }

        public int? Nro { get; set; }

        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(50)]
        public string Telefono { get; set; } = string.Empty;

        public int? IdLocalidad { get; set; }
    }
}