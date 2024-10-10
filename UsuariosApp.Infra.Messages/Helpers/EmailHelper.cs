using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Infra.Messages.Helpers
{
    public class EmailHelper
    {
        /// <summary>
        /// Método para envio de emails usando uma conta padrão do Outlook
        /// </summary>
        /// <param name="to">Email do destinatário</param>
        /// <param name="subject">Assunto da mensagem</param>
        /// <param name="body">Corpo da mensagem</param>
        public static void Send(string to, string subject, string body)
        {
            #region Parâmetros da conta de email

            var conta = "sergiojavaarq@outlook.com";
            var senha = "@Admin12345";
            var smtp = "smtp-mail.outlook.com";
            var porta = 587;

            #endregion

            #region Realizando o envio do email

            var mailMessage = new MailMessage(conta, to); //remetente e destinatário
            mailMessage.Subject = subject; //assunto da mensagem
            mailMessage.Body = body; //corpo da mensagem

            var smtpClient = new SmtpClient(smtp, porta); //configurações do servidor de email
            smtpClient.EnableSsl = true; //envio de email com criptografia
            smtpClient.Credentials = new NetworkCredential(conta, senha); //autenticação da conta
            smtpClient.Send(mailMessage); //enviando a mensagem

            #endregion
        }
    }
}
