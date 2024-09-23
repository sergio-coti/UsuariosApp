using Azure.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Tests.Helpers
{
    public static class TestHelper
    {
        //método para reutilizar a serialização dos dados em formato JSON
        public static StringContent Serialize(object request)
            => new StringContent
                (JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

        //método para criar o objeto HttpClient para fazer as requisições para a API
        public static HttpClient CreateClient()
            => new WebApplicationFactory<Program>().CreateClient();
    }
}
