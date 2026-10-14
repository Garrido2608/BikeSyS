namespace ApiBikeSyS.DTOs.RepuestoUsado
{
    public class RepuestoUsadoDTO
    {
        public int Id { get; set; }
        public int IdOrdenService { get; set; }
        public int IdRepuesto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}