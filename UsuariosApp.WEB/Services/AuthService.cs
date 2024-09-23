using Blazored.LocalStorage;
using UsuariosApp.WEB.Responses;

namespace UsuariosApp.WEB.Services
{
    /// <summary>
    /// Classe para manipularmos o conteúdo da LocalStorage
    /// para operações com o usuário autenticado no projeto
    /// </summary>
    public class AuthService
    {
        //atributos
        private readonly ILocalStorageService _localStorageService;

        //método construtor para inicializar o atributo (injeção de dependência)
        public AuthService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        /// <summary>
        /// Método para gravar os dados do usuário autenticado na local storage
        /// </summary>
        public void Register(AutenticarUsuarioResponse response)
        {
            _localStorageService.SetItemAsync("auth", response);
        }

        /// <summary>
        /// Método para ler e retornar os dados gravados na local storage
        /// </summary>
        public async Task<AutenticarUsuarioResponse> GetData()
        {
            return await _localStorageService.GetItemAsync<AutenticarUsuarioResponse>("auth");
        }

        /// <summary>
        /// Método para apagar os dados gravados na loca storage
        /// </summary>
        public async Task Remove()
        {
            await _localStorageService.RemoveItemAsync("auth");
        }
    }
}
