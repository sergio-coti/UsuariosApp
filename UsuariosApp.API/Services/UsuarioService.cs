﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApp.API.Contexts;
using UsuariosApp.API.Dtos.Requests;
using UsuariosApp.API.Dtos.Responses;
using UsuariosApp.API.Entities;
using UsuariosApp.API.Settings;

namespace UsuariosApp.API.Services
{
    public class UsuarioService
    {
        private readonly DataContext _dataContext;
        private readonly JwtSettings _jwtSettings;

        public UsuarioService(DataContext dataContext, JwtSettings jwtSettings)
        {
            _dataContext = dataContext;
            _jwtSettings = jwtSettings;
        }

        public async Task<CriarUsuarioResponseDto> CriarAsync(CriarUsuarioRequestDto dto)
        {
            if (_dataContext.Usuarios.Any(u => u.Email.Equals(dto.Email)))
                throw new ApplicationException("O email informado já está em uso.");

            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha
            };

            await _dataContext.Usuarios.AddAsync(usuario);
            await _dataContext.SaveChangesAsync();

            return new CriarUsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }

        public async Task<AutenticarUsuarioResponseDto> AutenticarAsync(AutenticarUsuarioRequestDto dto)
        {
            var usuario = await _dataContext.Usuarios.FirstOrDefaultAsync(u => u.Email.Equals(dto.Email) && u.Senha.Equals(dto.Senha));
            if (usuario == null)
                throw new ApplicationException("Usuário não encontrado.");

            // Gerar o RefreshToken e a data de expiração
            var refreshToken = GenerateRefreshToken();
            var refreshTokenExpiration = DateTime.Now.AddHours(_jwtSettings.RefreshTokenExpiration.Value); // Defina a expiração com base nas configurações

            // Atualizar o usuário com o RefreshToken e a data de expiração
            usuario.RefreshToken = refreshToken;
            usuario.RefreshTokenExpiration = refreshTokenExpiration;
            _dataContext.Usuarios.Update(usuario);
            await _dataContext.SaveChangesAsync();

            return new AutenticarUsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                AccessToken = GenerateToken(usuario.Email),
                RefreshToken = refreshToken
            };
        }

        public async Task<AutenticarUsuarioResponseDto> RefreshTokenAsync(string refreshToken)
        {
            var usuario = await _dataContext.Usuarios
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (usuario == null || usuario.RefreshTokenExpiration < DateTime.Now)
                throw new ApplicationException("Refresh token inválido ou já expirado.");

            usuario.RefreshToken = GenerateRefreshToken();
            await _dataContext.SaveChangesAsync();

            return new AutenticarUsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                AccessToken = GenerateToken(usuario.Email),
                RefreshToken = usuario.RefreshToken
            };
        }

        private string GenerateToken(string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email)
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.AccessTokenExpiration)),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
