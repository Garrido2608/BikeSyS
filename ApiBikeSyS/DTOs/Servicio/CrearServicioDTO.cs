using System.ComponentModel.DataAnnotations;

namespace ApiBikeSyS.DTOs.Servicio
{
    public class CrearServicioDTO
    {
        [Required]
        public int IdOrdenService { get; set; }

        [Required]
        public int IdTipoServicio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal Costo { get; set; }
    }
}