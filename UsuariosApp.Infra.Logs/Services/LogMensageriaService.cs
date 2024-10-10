using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Infra.Logs.Collections;
using UsuariosApp.Infra.Logs.Contexts;

namespace UsuariosApp.Infra.Logs.Services
{
    public class LogMensageriaService
    {
        /// <summary>
        /// Método para gravar um registro de log no banco do mongodb
        /// </summary>
        public void Create(LogMensageria logMensageria)
        {
            //abrindo conexão com o banco
            var mongoDBContext = new MongoDBContext();
            //gravando um registro na collection do mongodb
            mongoDBContext.LogMensageria.InsertOne(logMensageria);
        }
    }
}
