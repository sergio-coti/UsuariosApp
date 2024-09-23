using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Data.Contexts;
using UsuariosApp.Data.Entities;

namespace UsuariosApp.Data.Repositories
{
    public class UsuarioRepository
    {
        public void Add(Usuario usuario)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(usuario);
                dataContext.SaveChanges();
            }
        }

        public void Update(Usuario usuario)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(usuario);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Usuario usuario)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(usuario);
                dataContext.SaveChanges();
            }
        }

        public List<Usuario> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Usuario>()
                    .Include(u => u.Perfil)
                    .OrderBy(u => u.Nome)
                    .ToList();
            }
        }

        public Usuario? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Usuario>()
                    .Include(u => u.Perfil)
                    .FirstOrDefault(u => u.Id == id);
            }
        }

        public Usuario? GetByEmail(string email)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Usuario>()
                    .Include(u => u.Perfil)
                    .FirstOrDefault(u => u.Email.Equals(email));
            }
        }

        public Usuario? GetByEmailAndSenha(string email, string senha)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Usuario>()
                    .Include(u => u.Perfil)
                    .FirstOrDefault(u => u.Email.Equals(email)
                                      && u.Senha.Equals(senha));
            }
        }
    }
}
