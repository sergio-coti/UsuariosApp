using System.ComponentModel.DataAnnotations;

namespace UsuariosApp.WEB.ViewModels
{
    /// <summary>
    /// Modelo de dados para capturar os campos do formulário
    /// da página de autenticação de usuários.
    /// </summary>
    public class AutenticarUsuarioViewModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o seu email de acesso.")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a sua senha de acesso.")]
        public string? Senha { get; set; }
    }
}
