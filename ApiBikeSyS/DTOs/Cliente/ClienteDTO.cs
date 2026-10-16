namespace ApiBikeSyS.DTOs.Cliente
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string? DNI { get; set; }
        public string? Calle { get; set; }
        public int? Nro { get; set; }
        public string? Email { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public int? IdLocalidad { get; set; }
    }
}