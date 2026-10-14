namespace ApiBikeSyS.DTOs.HistorialEstado
{
    public class HistorialEstadoDTO
    {
        public int Id { get; set; }
        public int IdOrdenService { get; set; }
        public int IdEstado { get; set; }
        public DateTime Fecha { get; set; }
    }
}