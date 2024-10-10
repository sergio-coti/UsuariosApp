using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Infra.Logs.Settings
{
    /// <summary>
    /// Classe para definir os parâmetros de conexão com o MongoDB
    /// </summary>
    public class MongoDBSettings
    {
        /// <summary>
        /// Caminho para conexão com o servidor do MongoDB
        /// </summary>
        public static string ConnectionString => "mongodb://localhost:27017";

        /// <summary>
        /// Nome do banco de dados do MongoDB
        /// </summary>
        public static string Database => "DBUsuariosApp";
    }
}
