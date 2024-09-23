using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using UsuariosApp.API.Models.Requests;
using UsuariosApp.Tests.Helpers;
using Xunit;

namespace UsuariosApp.Tests
{
    public class UsuariosTest
    {
        //atributo da classe de teste
        Faker faker = new Faker("pt_BR");

        [Fact]
        public void CriarUsuarioComSuceso()
        {
            //criando uma requisição para cadastro de usuário na API
            var request = new CriarUsuarioRequest
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Teste123"
            };

            //fazendo a requisição para o ENDPOINT
            var response = TestHelper.CreateClient()
                .PostAsync("/api/usuarios/criar", TestHelper.Serialize(request)).Result;

            //verificando se a API retornou código HTTP 201 (CREATED)
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public void CriarUsuarioComEmailJaCadastrado()
        {
            var request = new CriarUsuarioRequest
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Teste123"
            };

            HttpResponseMessage response = null;
            
            //criando o usuário com sucesso.
            response = TestHelper.CreateClient()
                .PostAsync("/api/usuarios/criar", TestHelper.Serialize(request)).Result;
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            //retornar erro BAD REQUEST (400) - Usuário já existe
            response = TestHelper.CreateClient()
                .PostAsync("/api/usuarios/criar", TestHelper.Serialize(request)).Result;
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void AutenticarUsuarioComSucesso()
        {
            var requestCriarUsuario = new CriarUsuarioRequest
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Teste123"
            };

            HttpResponseMessage response = null;

            //criando o usuário com sucesso.
            response = TestHelper.CreateClient()
                .PostAsync("/api/usuarios/criar", TestHelper.Serialize(requestCriarUsuario)).Result;
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var requestAutenticarUsuario = new AutenticarUsuarioRequest
            {
                Email = requestCriarUsuario.Email,
                Senha = requestCriarUsuario.Senha
            };

            response = TestHelper.CreateClient()
                .PostAsync("/api/usuarios/autenticar", TestHelper.Serialize(requestAutenticarUsuario)).Result;
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public void AcessoNegadoDeUsuario()
        {
            var request = new AutenticarUsuarioRequest
            {
                Email = faker.Internet.Email(),
                Senha = "@AcessoNegado2024"
            };

            var response = TestHelper.CreateClient()
                .PostAsync("/api/usuarios/autenticar", TestHelper.Serialize(request)).Result;
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact(Skip = "Não implementado.")]
        public void ObterDadosComSucesso()
        {

        }
    }
}