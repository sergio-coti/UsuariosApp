namespace UsuariosApp.API.Models.Services
{
    /// <summary>
    /// Modelo de dados do serviço de envio de mensagens
    /// </summary>
    public class EmailServiceModel
    {
        public string? EmailDestinatario { get; set; }
        public string? Assunto { get; set; }
        public string? Mensagem { get; set; }
    }
}
