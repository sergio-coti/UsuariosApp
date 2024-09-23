namespace UsuariosApp.WEB.Responses
{
    /// <summary>
    /// Classe de modelo de dados para capturar a resposta
    /// da API após a autenticação do usuário.
    /// </summary>
    public class AutenticarUsuarioResponse
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataHoraAcesso { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? DataHoraExpiracao { get; set; }
    }
}
