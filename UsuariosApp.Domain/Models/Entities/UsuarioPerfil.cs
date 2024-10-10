using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Models.Entities
{
    public class UsuarioPerfil
    {
        public Guid? UsuarioId { get; set; }
        public Guid? PerfilId { get; set; }

        #region Relacionamentos

        public Usuario? Usuario { get; set; }
        public Perfil? Perfil { get; set; }

        #endregion
    }
}
