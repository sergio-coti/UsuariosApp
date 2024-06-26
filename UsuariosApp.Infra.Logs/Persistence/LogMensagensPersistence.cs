﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Infra.Logs.Collections;
using UsuariosApp.Infra.Logs.Contexts;

namespace UsuariosApp.Infra.Logs.Persistence
{
    /// <summary>
    /// Classe para gravação dos logs no MongoDB
    /// </summary>
    public class LogMensagensPersistence
    {
        public void Insert(LogMensagens log)
        {
            var mongoDBContext = new MongoDBContext();
            mongoDBContext.LogMensagens.InsertOne(log);
        }
    }
}
