using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.API.Dtos.Requests;
using UsuariosApp.API.Dtos.Responses;
using UsuariosApp.API.Services;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("criar")]
        [ProducesResponseType(typeof(CriarUsuarioResponseDto), 201)]
        public async Task<IActionResult> Criar([FromBody] CriarUsuarioRequestDto dto)
        {
            try
            {
                return StatusCode(201, await _usuarioService.CriarAsync(dto));
            }
            catch(ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
        }

        [HttpPost("autenticar")]
        [ProducesResponseType(typeof(AutenticarUsuarioResponseDto), 200)]
        public async Task<IActionResult> Autenticar([FromBody] AutenticarUsuarioRequestDto dto)
        {
            try
            {
                return StatusCode(200, await _usuarioService.AutenticarAsync(dto));
            }
            catch (ApplicationException e)
            {
                return StatusCode(401, new { e.Message });
            }
        }


        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            return Ok();
        }
    }
}
