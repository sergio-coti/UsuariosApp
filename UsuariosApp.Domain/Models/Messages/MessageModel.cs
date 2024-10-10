using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Models.Messages
{
    /// <summary>
    /// Modelo de dados para envio de mensagens para a fila da mensageria
    /// </summary>
    public class MessageModel
    {
        public string? EmailDestinatario { get; set; }
        public string? Assunto { get; set; }
        public string? Texto { get; set; }
    }
}
