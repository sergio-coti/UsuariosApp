using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Interfaces.Security;
using UsuariosApp.Domain.Models.Entities;
using UsuariosApp.Infra.Security.Settings;

namespace UsuariosApp.Infra.Security.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        public string CreateToken(Usuario usuario)
        {
            //chave para assinatura dos tokens (criptografia)
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtTokenSettings.SecretKey);

            //construindo o conteúdo do token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //gravando o email do usuário no conteúdo do TOKEN (identificação do usuário)
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, usuario.Email) }),
                
                //data de expiração do TOKEN
                Expires = GetExpiration(),

                //chave secreta para assinatura do TOKEN (antifalsificação)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            //gerando e retornando o TOKEN JWT
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public DateTime? GetExpiration()
        {
            return DateTime.UtcNow.AddHours(JwtTokenSettings.ExpirationInHours);
        }
    }
}
