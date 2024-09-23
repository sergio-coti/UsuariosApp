
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net;
using System.Net.Mail;
using System.Text;
using UsuariosApp.API.Models.Services;
using UsuariosApp.API.Settings;

namespace UsuariosApp.API.Services
{
    /// <summary>
    /// Componente para ler e processar conteúdo da fila
    /// </summary>
    public class RabbitMQConsumer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConnection _connection;
        private readonly IModel _model;

        public RabbitMQConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            //definindo a conexão com o servidor da mensageria
            var connectionFactory = new ConnectionFactory { Uri = new Uri(RabbitMQSettings.Url) };
            //abrindo conexão com o servidor
            _connection = connectionFactory.CreateConnection();

            //acessando a fila
            _model = _connection.CreateModel();
            _model.QueueDeclare(
                queue: RabbitMQSettings.Queue, //nome da fila que estamos acessando
                durable: true, //fila permanente
                exclusive: false, //fila compartilhada com outros projetos
                autoDelete: false, //os itens processados na fila não são removidos de forma automática
                arguments: null //sem argumentos
                );
        }

        /// <summary>
        /// Método que será executado em tempo real para fazer a leitura
        /// contínua do conteúdo da fila.
        /// </summary>
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            #region Parâmetros para realização do envio de email

            string conta = "sergiojavaarq@outlook.com";
            string senha = "@Admin12345";
            string smtp = "smtp-mail.outlook.com";
            int porta = 587;

            #endregion

            #region Ler e processar cada mensagem contida na fila

            var consumer = new EventingBasicConsumer(_model);

            consumer.Received += (sender, args) =>
            {
                var contentArray = args.Body.ToArray();
                var contentJson = Encoding.UTF8.GetString(contentArray);

                //deserializar os dados que foram gravados na fila
                var mensagem = JsonConvert.DeserializeObject<EmailServiceModel>(contentJson);

                //fazer o envio do email para o usuário
                using (var scope = _serviceProvider.CreateScope())
                {
                    //criando o conteúdo da mensagem de email
                    var mailMessage = new MailMessage(conta, mensagem.EmailDestinatario);
                    mailMessage.Subject = mensagem.Assunto;
                    mailMessage.Body = mensagem.Mensagem;

                    //enviando o email para o usuário
                    var smtpClient = new SmtpClient(smtp, porta);
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential(conta, senha);
                    smtpClient.Send(mailMessage);

                    //retirar a mensagem da fila
                    _model.BasicAck(args.DeliveryTag, false);
                }
            };

            _model.BasicConsume(RabbitMQSettings.Queue, false, consumer);
            return Task.CompletedTask;

            #endregion
        }
    }
}
