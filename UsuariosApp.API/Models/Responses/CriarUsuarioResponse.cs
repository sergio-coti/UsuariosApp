namespace UsuariosApp.API.Models.Responses
{
    public class CriarUsuarioResponse
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
    }
}
