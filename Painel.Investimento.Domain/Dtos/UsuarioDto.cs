namespace Painel.Investimento.Application.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = "user";
    }
}
