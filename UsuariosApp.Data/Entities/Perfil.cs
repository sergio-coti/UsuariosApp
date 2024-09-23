using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Data.Entities
{
    public class Perfil
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }

        public List<Usuario>? Usuarios { get; set; }
    }
}
