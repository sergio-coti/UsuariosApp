using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using UsuariosApp.API.Models.Services;
using UsuariosApp.API.Settings;

namespace UsuariosApp.API.Services
{
    /// <summary>
    /// Componente para gravar conteúdo na fila
    /// </summary>
    public class RabbitMQProducer
    {
        /// <summary>
        /// Método para conexão e gravação da mensagem na fila.
        /// </summary>
        public void SendMessage(EmailServiceModel model)
        {
            //conectar no servidor da mensageria (RabbitMQ)
            var connectionFactory = new ConnectionFactory { Uri = new Uri(RabbitMQSettings.Url) };
            using (var connection = connectionFactory.CreateConnection())
            {
                //acessando ou criando a fila
                using (var queue = connection.CreateModel())
                {
                    //informações da fila que será criada / acessada
                    queue.QueueDeclare(
                        queue: RabbitMQSettings.Queue, //nome da fila
                        durable: true, //fila nunca será apagada
                        exclusive: false, //fila poderá ser acessada por outras aplicações
                        autoDelete: false, //fila não irá remover seus itens automaticamente
                        arguments: null
                        );

                    //gravando o conteúdo da mensagem na fila
                    queue.BasicPublish(
                        routingKey: RabbitMQSettings.Queue, //nome da fila
                        body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model)),
                        exchange: string.Empty,
                        basicProperties: null
                        );
                }
            }
        }
    }
}
