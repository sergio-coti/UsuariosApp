using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Models.Entities;

namespace UsuariosApp.Domain.Interfaces.Security
{
    public interface IJwtTokenService
    {
        /// <summary>
        /// Método para criar e retornar o TOKEN JWT do usuário
        /// </summary>
        string CreateToken(Usuario usuario);

        /// <summary>
        /// Método para retornar a data e hora de expiração do TOKEN JWT
        /// </summary>
        DateTime? GetExpiration();
    }
}
