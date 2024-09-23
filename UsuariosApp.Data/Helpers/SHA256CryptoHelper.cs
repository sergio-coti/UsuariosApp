using System;
using System.Security.Cryptography;
using System.Text;

namespace UsuariosApp.Data.Helpers
{
    public class SHA256CryptoHelper
    {
        public static string Encrypt(string value)
        {
            using (var sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                var builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));

                return builder.ToString();
            }
        }
    }
}
