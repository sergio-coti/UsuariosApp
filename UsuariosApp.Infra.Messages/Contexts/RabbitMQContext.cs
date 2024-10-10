using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Infra.Messages.Settings;

namespace UsuariosApp.Infra.Messages.Contexts
{
    /// <summary>
    /// Classe para conexão com o servidor do RabbitMQ
    /// </summary>
    public class RabbitMQContext
    {
        /// <summary>
        /// Método para retornar uma conexão com o servidor da mensageria
        /// </summary>
        public IConnection CreateConnection()
        {
            //definindo o caminho (URL) do servidor
            var connectionFactory = new ConnectionFactory() { Uri = new Uri(RabbitMQSettings.Url) };

            //abrindo conexão com o servidor da mensageria e retornando a conexão
            return connectionFactory.CreateConnection();
        }

        public IModel CreateModel(IConnection connection)
        {
            //criando a fila (armazenamento das mensagens)
            var model = connection.CreateModel();
            model.QueueDeclare(
                queue: RabbitMQSettings.Queue, //nome da fila que será criada
                durable: true, //a fila não será apagada caso o servidor seja reiniciado
                autoDelete: false, //servidor não remover itens da fila de forma automatica
                exclusive: false, //servidor permitir a conexão de multiplas aplicações
                arguments: null
            );
            return model;
        }
    }
}
