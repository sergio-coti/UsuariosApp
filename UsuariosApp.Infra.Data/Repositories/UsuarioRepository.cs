using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Models.Entities;
using UsuariosApp.Infra.Data.Contexts;

namespace UsuariosApp.Infra.Data.Repositories
{
    /// <summary>
    /// Classe para implementar as operações do repositório
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Create(Usuario usuario)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(usuario);
                dataContext.SaveChanges();
            }
        }

        public bool IsExists(string email)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Usuario>()
                    .Count(u => u.Email.Equals(email)) > 0;
            }
        }

        public Usuario? Get(string email, string senha)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Usuario>()
                    .FirstOrDefault(u => u.Email.Equals(email)
                                      && u.Senha.Equals(senha));
            }
        }
    }
}
