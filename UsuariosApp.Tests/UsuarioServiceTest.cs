using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.API.Contexts;
using UsuariosApp.API.Dtos.Requests;
using UsuariosApp.API.Dtos.Responses;
using UsuariosApp.API.Services;
using UsuariosApp.API.Settings;
using Xunit;

namespace UsuariosApp.Tests
{
    /// <summary>
    /// Classe para testes unitários da camada de serviço de usuários
    /// </summary>
    public class UsuarioServiceTest
    {
        private readonly UsuarioService _usuarioService;
        private readonly DataContext _dataContext;

        public UsuarioServiceTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("UsuariosApp")
                .Options;

            var jwtSettings = new JwtSettings
            {
                SecretKey = "72879D4E-FBC4-454B-A4CF-57FCDE67867A",
                Issuer = "CotiInformatica",
                Audience = "CotiInformaticaUsers",
                AccessTokenExpiration = 10,
                RefreshTokenExpiration = 120
            };

            _dataContext = new DataContext(options);
            _usuarioService = new UsuarioService(_dataContext, jwtSettings);
        }

        [Fact]
        public async Task CriarAsync_Usuario_Valido_Deve_Retornar_CriarUsuarioResponseDto()
        {
            // Arrange
            var dto = new CriarUsuarioRequestDto
            {
                Nome = "Nome Teste",
                Email = "email@exemplo.com",
                Senha = "senha123"
            };

            // Act
            var result = await _usuarioService.CriarAsync(dto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<CriarUsuarioResponseDto>();
            result.Id.Should().NotBe(Guid.Empty);
            result.Nome.Should().Be(dto.Nome);
            result.Email.Should().Be(dto.Email);

            // Verificar se o usuário foi adicionado ao contexto
            var usuario = await _dataContext.Usuarios.FirstOrDefaultAsync(u => u.Email == dto.Email);
            usuario.Should().NotBeNull();
            usuario.Nome.Should().Be(dto.Nome);
        }

        [Fact]
        public async Task AutenticarAsync_Usuario_Valido_Deve_Retornar_AutenticarUsuarioResponseDto()
        {
            // Arrange
            var criarUsuarioDto = new CriarUsuarioRequestDto
            {
                Nome = "Nome Teste",
                Email = "email-auth@exemplo.com",
                Senha = "senha123"
            };

            // Adicionar um usuário válido ao banco de dados
            await _usuarioService.CriarAsync(criarUsuarioDto);

            var autenticarDto = new AutenticarUsuarioRequestDto
            {
                Email = "email-auth@exemplo.com",
                Senha = "senha123"
            };

            // Act
            var result = await _usuarioService.AutenticarAsync(autenticarDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<AutenticarUsuarioResponseDto>();
            result.Email.Should().Be(criarUsuarioDto.Email);
            result.Nome.Should().Be(criarUsuarioDto.Nome);
            result.AccessToken.Should().NotBeNullOrEmpty();
            result.RefreshToken.Should().NotBeNullOrEmpty();
        }

    }
}
