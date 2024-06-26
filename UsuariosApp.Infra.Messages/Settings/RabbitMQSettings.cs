﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Infra.Messages.Settings
{
    /// <summary>
    /// Classe para armazenar as configurações de conexão
    /// com o servidor da mensageria (RabbitMQ)
    /// </summary>
    public class RabbitMQSettings
    {
        /// <summary>
        /// Caminho do servidor do RabbitMQ
        /// </summary>
        public static string RabbitUrl => "amqps://temlmpkr:JJIyT0uXeUjUjc_OCgyjpfRklw5aizRg@shark.rmq.cloudamqp.com/temlmpkr";

        /// <summary>
        /// Nome da fila no RabbitMQ
        /// </summary>
        public static string RabbitQueue => "emails_usuario";
    }
}
