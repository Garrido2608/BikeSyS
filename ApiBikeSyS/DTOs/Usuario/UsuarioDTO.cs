namespace ApiBikeSyS.DTOs.Usuario
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}