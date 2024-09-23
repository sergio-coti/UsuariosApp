namespace UsuariosApp.API.Settings
{
    /// <summary>
    /// Classe para armazenar os parâmetros de conexão
    /// com o servidor do RabbitMQ (servidor de mensageria)
    /// </summary>
    public class RabbitMQSettings
    {
        /// <summary>
        /// Caminho para conexão com o servidor
        /// </summary>
        public static string Url => @"amqps://yviadrgy:xAMmGmiFwnYcBUmoGedrVX1hMU095aYr@woodpecker.rmq.cloudamqp.com/yviadrgy";

        /// <summary>
        /// Nome da fila que será criada / acessada no servidor
        /// </summary>
        public static string Queue => "mensagens-usuarios";
    }
}
