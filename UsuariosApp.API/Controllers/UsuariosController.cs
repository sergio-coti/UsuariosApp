using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.API.Models.Requests;
using UsuariosApp.API.Models.Responses;
using UsuariosApp.API.Models.Services;
using UsuariosApp.API.Security;
using UsuariosApp.API.Services;
using UsuariosApp.Data.Entities;
using UsuariosApp.Data.Helpers;
using UsuariosApp.Data.Repositories;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        public IActionResult Criar(CriarUsuarioRequest request)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();
                var perfilRepository = new PerfilRepository();

                //verificando se o email informado já está cadastrado no banco de dados
                if(usuarioRepository.GetByEmail(request.Email) != null)
                {
                    //HTTP 400 (BAD REQUEST)
                    return StatusCode(400, new { message = "O email informado já está cadastrado. Tente outro." });
                }

                //preenchendo os dados do usuário
                var usuario = new Usuario();
                usuario.Id = Guid.NewGuid();
                usuario.Nome = request.Nome;
                usuario.Email = request.Email;
                usuario.Senha = SHA256CryptoHelper.Encrypt(request.Senha);

                //associando o usuário ao perfil 'USER' no banco de dados
                var perfil = perfilRepository.GetByNome("USER");
                usuario.PerfilId = perfil.Id; //chave estrangeira

                //gravando o usuário no banco de dados
                usuarioRepository.Add(usuario);

                //escrevendo a mensagem de boas vindas que será enviada para o usuário
                var emailServiceModel = new EmailServiceModel();
                emailServiceModel.EmailDestinatario = usuario.Email;
                emailServiceModel.Assunto = "Confirmação de cadastro de usuário - COTI Informática.";
                emailServiceModel.Mensagem = $"Olá, {usuario.Nome}.\nSua conta foi criada com sucesso.\n\nEquipe COTI.";

                //enviando para o servidor da mensageria
                var rabbitMQProducer = new RabbitMQProducer();
                rabbitMQProducer.SendMessage(emailServiceModel);

                //retornando os dados do usuário criado
                var response = new CriarUsuarioResponse();
                response.Id = usuario.Id;
                response.Nome = usuario.Nome;
                response.Email = usuario.Email;
                response.DataHoraCadastro = DateTime.Now;

                //HTTP 201 (CREATED)
                return StatusCode(201, response);
            }
            catch(Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPost]
        [Route("autenticar")]
        public IActionResult Autenticar(AutenticarUsuarioRequest request) 
        {
            try
            {
                //consultando o usuário no banco de dados através do email e da senha
                var usuarioRepository = new UsuarioRepository();
                var usuario = usuarioRepository.GetByEmailAndSenha
                    (request.Email, SHA256CryptoHelper.Encrypt(request.Senha));


                //verificando se o usuário não foi encontrado
                if(usuario == null)
                {
                    //HTTP 401 (UNAUTHORIZED)
                    return StatusCode(401, new { message = "Acesso negado. Usuário não encontrado." });
                }
                else
                {
                    //retornando os dados do usuário autenticado
                    var response = new AutenticarUsuarioResponse();
                    response.Id = usuario.Id;
                    response.Nome = usuario.Nome;
                    response.Email = usuario.Email;
                    response.DataHoraAcesso = DateTime.Now;
                    response.AccessToken = JwtBearerSecurity.CreateToken(usuario);
                    response.DataHoraExpiracao = DateTime.Now.AddHours(JwtBearerSecurity.ExpirationInHours);

                    //HTTP 200 (OK)
                    return StatusCode(200, response);
                }
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("obter-dados")]
        public IActionResult ObterDados() 
        {
            try
            {
                //obtendo a chave do usuário contido no TOKEN:
                var email = User.Identity.Name;

                //consultando os dados do usuário baseado no email obtido
                var usuarioRepository = new UsuarioRepository();
                var usuario = usuarioRepository.GetByEmail(email);

                //retornando os dados do usuário
                var response = new ObterDadosUsuarioResponse();
                response.Id = usuario.Id;
                response.Nome = usuario.Nome;
                response.Email = usuario.Email;
                response.Perfil = usuario.Perfil.Nome;

                //retornando os dados do usuário
                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
