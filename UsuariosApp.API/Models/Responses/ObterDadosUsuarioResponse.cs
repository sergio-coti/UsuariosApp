namespace UsuariosApp.API.Models.Responses
{
    public class ObterDadosUsuarioResponse
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Perfil { get; set; }
    }
}
