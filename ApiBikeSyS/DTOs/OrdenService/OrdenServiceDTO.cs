namespace ApiBikeSyS.DTOs.OrdenService
{
    public class OrdenServiceDTO
    {
        public int Id { get; set; }
        public int IdBicicleta { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public decimal TotalGeneral { get; set; }
    }
}