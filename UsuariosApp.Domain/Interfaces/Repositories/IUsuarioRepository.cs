using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Models.Entities;

namespace UsuariosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface de reposítório de dados para usuário
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Método para inserir um usuário no banco de dados
        /// </summary>
        void Create(Usuario usuario);

        /// <summary>
        /// Método para verificar se um email já está cadastrado no banco de dados
        /// </summary>
        bool IsExists(string email);

        /// <summary>
        /// Método para obter 1 usuário no banco de dados através do email e da senha
        /// </summary>
        Usuario? Get(string email, string senha);
    }
}
