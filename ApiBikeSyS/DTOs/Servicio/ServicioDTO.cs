namespace ApiBikeSyS.DTOs.Servicio
{
    public class ServicioDTO
    {
        public int Id { get; set; }
        public int IdOrdenService { get; set; }
        public int IdTipoServicio { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
    }
}