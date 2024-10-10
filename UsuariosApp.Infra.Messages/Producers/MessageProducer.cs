using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Interfaces.Messages;
using UsuariosApp.Infra.Messages.Contexts;
using UsuariosApp.Infra.Messages.Settings;

namespace UsuariosApp.Infra.Messages.Producers
{
    /// <summary>
    /// Classe para implementar a rotina de gravação de mensagens
    /// na fila do servidor de mensageria
    /// </summary>
    public class MessageProducer : IMessageProducer
    {
        public void Send(string message)
        {
            //instanciando a classe de contexto do RabbitMQ
            var context = new RabbitMQContext();

            //conectando no servidor da mensageria
            using (var connection = context.CreateConnection())
            using (var model = context.CreateModel(connection))
            {
                //gravar a mensagem na fila
                model.BasicPublish(
                    exchange: string.Empty,
                    routingKey: RabbitMQSettings.Queue,
                    basicProperties: null,
                    body: Encoding.UTF8.GetBytes(message)
                );
            }
        }
    }
}
