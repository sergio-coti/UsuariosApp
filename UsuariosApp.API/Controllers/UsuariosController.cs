using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Models.Dtos;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {       
        //atrbuto
        private readonly IUsuarioDomainService _usuarioDomainService;
        
        //método construtor para injeção de dependência (inicialização dos atributos)
        public UsuariosController(IUsuarioDomainService usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        /// <summary>
        /// Endpoint da API para criação de usuário
        /// </summary>
        [HttpPost] //método HTTP
        [Route("criar")] //ENDPOINT: /api/usuarios/criar
        [ProducesResponseType(typeof(CriarUsuarioResponseDto), 201)]
        public IActionResult Criar(CriarUsuarioRequestDto request)
        {
            try
            {
                //executando a criação do usuário na camada de domínio
                var response = _usuarioDomainService.Criar(request);

                //HTTP 201 (CREATED)
                return StatusCode(201, response);
            }
            catch(ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch(Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = $"Falha ao criar usuário: {e.Message}" });
            }
        }

        /// <summary>
        /// Endpoint da API para autenticãção de usuário
        /// </summary>
        [HttpPost] //método HTTP POST
        [Route("autenticar")] //ENDPOINT: /api/usuarios/autenticar
        [ProducesResponseType(typeof(AutenticarUsuarioResponseDto), 200)]
        public IActionResult Autenticar(AutenticarUsuarioRequestDto request)
        {
            try
            {
                //executando a autenticação do usuário na camada de domínio
                var response = _usuarioDomainService.Autenticar(request);

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch(ApplicationException e)
            {
                //HTTP 401 (UNAUTHORIZED)
                return StatusCode(401, new { mensagem = e.Message });
            }
            catch(Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = $"Falha ao autenticar usuário: {e.Message}" });
            }
        }
    }
}
