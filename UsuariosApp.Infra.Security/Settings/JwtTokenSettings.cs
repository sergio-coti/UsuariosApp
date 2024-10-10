using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Infra.Security.Settings
{
    /// <summary>
    /// Classe para configurar os parâmetros para geração do TOKEN
    /// </summary>
    public class JwtTokenSettings
    {
        /// <summary>
        /// Chave secreta para criptografia e assinatura dos TOKENS JWT
        /// </summary>
        public static string SecretKey => "E97A6687-96AC-408A-9E97-D2CF8202EA4D";

        /// <summary>
        /// Tempo de expiração do TOKEN JWT em horas
        /// </summary>
        public static int ExpirationInHours => 1;
    }
}
