namespace UsuariosApp.WEB.Responses
{
    /// <summary>
    /// Classe de modelo de dados para capturar a resposta
    /// da API após a consulta dos dados do usuário.
    /// </summary>
    public class ObterDadosUsuarioResponse
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Perfil { get; set; }
    }
}
