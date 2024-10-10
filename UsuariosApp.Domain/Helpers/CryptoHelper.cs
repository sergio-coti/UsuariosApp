using System.Security.Cryptography;
using System.Text;

namespace UsuariosApp.Domain.Helpers
{
    /// <summary>
    /// Classe auxiliar para rotinas de criptografia de dados
    /// </summary>
    public class CryptoHelper
    {
        /// <summary>
        /// Método para criptografar um valor utilizando HASH SHA 256
        /// </summary>
        public static string CreateSHA256(string value)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(value);
                var hashBytes = sha256.ComputeHash(bytes);

                var builder = new StringBuilder();
                foreach (byte b in hashBytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }
    }
}