using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Infra.Logs.Collections;
using UsuariosApp.Infra.Logs.Settings;

namespace UsuariosApp.Infra.Logs.Contexts
{
    /// <summary>
    /// Classe para conexão com o banco de dados do MongoDB
    /// </summary>
    public class MongoDBContext
    {
        //atributos
        private IMongoDatabase _mongoDatabase;

        //método construtor [ctor] + [tab]
        public MongoDBContext()
        {
            //definir o caminho do banco de dados
            var settings = MongoClientSettings.FromUrl(new MongoUrl(MongoDBSettings.ConnectionString));

            //abrindo conexão com o banco de dados
            var mongoClient = new MongoClient (settings);
            _mongoDatabase = mongoClient.GetDatabase(MongoDBSettings.Database);
        }

        //mapeamento das collections do banco de dados
        public IMongoCollection<LogMensageria> LogMensageria
            => _mongoDatabase.GetCollection<LogMensageria>("LogMensageria");
    }
}
