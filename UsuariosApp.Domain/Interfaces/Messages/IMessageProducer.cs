using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Interfaces.Messages
{
    /// <summary>
    /// Interface para definir os métodos que irão 
    /// gravar conteudo no servidor de mensageria
    /// </summary>
    public interface IMessageProducer
    {
        /// <summary>
        /// Método para gravar uma mensagem na fila do servidor da mensageria
        /// </summary>
        void Send(string message);
    }
}
