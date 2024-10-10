using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Infra.Logs.Collections
{
    /// <summary>
    /// Modelo de dados para gravação dos logs da mensageria
    /// no banco de dados do MongoDB
    /// </summary>
    public class LogMensageria
    {
        public Guid Id { get; set; }
        public DateTime? DataHora { get; set; }
        public string? Status { get; set; }
        public string? Descricao { get; set; }
    }
}
