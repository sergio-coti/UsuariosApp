using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Models.Messages;
using UsuariosApp.Infra.Logs.Collections;
using UsuariosApp.Infra.Logs.Services;
using UsuariosApp.Infra.Messages.Contexts;
using UsuariosApp.Infra.Messages.Helpers;
using UsuariosApp.Infra.Messages.Settings;

namespace UsuariosApp.Infra.Messages.Consumers
{
    /// <summary>
    /// Esta classe irá funcionar como um serviço que será incializado
    /// no momento em que o projeto for executado
    /// </summary>
    public class MessageConsumer : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var context = new RabbitMQContext();

            using (var connection = context.CreateConnection())
            using (var model = context.CreateModel(connection))
            {
                //objeto para ler e processar cada mensagem da fila
                var consumer = new EventingBasicConsumer(model);

                //ler o conteúdo da fila
                consumer.Received += (cons, args) =>
                {
                    //lendo a mensagem contida na fila (formato JSON)
                    var body = args.Body.ToArray();
                    var json = Encoding.UTF8.GetString(body);

                    //deserializando este conteúdo JSON para objeto
                    var messageModel = JsonConvert.DeserializeObject<MessageModel>(json);

                    try
                    {
                        //enviando a mensagem por email
                        EmailHelper.Send(messageModel.EmailDestinatario, messageModel.Assunto, messageModel.Texto);

                        //dados do log descrevendo sucesso
                        var logMensageria = new LogMensageria
                        {
                            Id = Guid.NewGuid(),
                            DataHora = DateTime.Now,
                            Status = "SUCESSO",
                            Descricao = $"Email enviado com sucesso para o usuário: {messageModel.EmailDestinatario}"
                        };

                        //gravando o log
                        var logMensageriaService = new LogMensageriaService();
                        logMensageriaService.Create(logMensageria);
                    }
                    catch(Exception e)
                    {
                        //dados do log descrevendo erro
                        var logMensageria = new LogMensageria
                        {
                            Id = Guid.NewGuid(),
                            DataHora = DateTime.Now,
                            Status = "ERRO",
                            Descricao = $"Falha ao enviar email para o usuário: {messageModel.EmailDestinatario}. {e.Message}"
                        };

                        //gravando o log
                        var logMensageriaService = new LogMensageriaService();
                        logMensageriaService.Create(logMensageria);
                    }                    

                    //confirmando o processamento da mensagen com sucesso na fila
                    model.BasicAck(args.DeliveryTag, false);
                };

                //retirar cada mensagem lida da fila
                model.BasicConsume(
                    queue: RabbitMQSettings.Queue,
                    autoAck: false,
                    consumer: consumer
                    );

                //manter o serviço em execução..
                while(!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}
