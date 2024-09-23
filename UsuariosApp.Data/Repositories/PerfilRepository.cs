using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Data.Contexts;
using UsuariosApp.Data.Entities;

namespace UsuariosApp.Data.Repositories
{
    public class PerfilRepository
    {
        public void Add(Perfil perfil)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(perfil);
                dataContext.SaveChanges();
            }
        }

        public void Update(Perfil perfil)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(perfil);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Perfil perfil)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(perfil);
                dataContext.SaveChanges();
            }
        }

        public List<Perfil> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Perfil>()
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
        }

        public Perfil? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Perfil>()
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public Perfil? GetByNome(string nome)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Perfil>()
                    .FirstOrDefault(p => p.Nome.Equals(nome));
            }
        }
    }
}
