using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Models.Dtos;
using Xunit;

namespace UsuariosApp.Tests
{
    /// <summary>
    /// Classe para testes de integração 
    /// com os serviços da API de usuários
    /// </summary>
    public class UsuariosTest
    {
        /// <summary>
        /// Método para realizar os testes de integração
        /// com o serviço de criação de usuários da API
        /// </summary>
        [Fact]
        public void CriarUsuariosTest()
        {
            //biblioteca para massa de dados de teste (Bogus)
            var faker = new Faker("pt_BR");

            //criando os dados que serão enviados para a API para execução do teste
            var request = new CriarUsuarioRequestDto
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Teste123"
            };

            //serializando os dados em formato JSON
            var json = new StringContent(JsonConvert.SerializeObject(request),
                            Encoding.UTF8, "application/json");

            //executando o serviço de cadastro de usuários da API
            var client = new WebApplicationFactory<Program>().CreateClient();
            var response = client.PostAsync("/api/usuarios/criar", json).Result;

            //verificando se a API retornou código HTTP 201 (CREATED)
            //utilizando a biblioteca do Fluent Assertions
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);
        }
    }
}
