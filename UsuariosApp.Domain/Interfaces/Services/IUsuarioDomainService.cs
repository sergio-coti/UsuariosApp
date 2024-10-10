using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Models.Dtos;

namespace UsuariosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para definirmos os métodos de serviço de domínio para usuário
    /// </summary>
    public interface IUsuarioDomainService
    {
        CriarUsuarioResponseDto Criar(CriarUsuarioRequestDto request);
        AutenticarUsuarioResponseDto Autenticar(AutenticarUsuarioRequestDto request);
    }
}
