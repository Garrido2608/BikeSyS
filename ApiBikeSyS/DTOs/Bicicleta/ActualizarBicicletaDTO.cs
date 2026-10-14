using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.Bicicleta
{
    public class ActualizarBicicletaDTO
    {
        [Required(ErrorMessage = "El cliente es obligatorio")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio")]
        public int IdModelo { get; set; }

        [Required(ErrorMessage = "El tipo de rueda es obligatorio")]
        public int IdTipoRueda { get; set; }
    }
}