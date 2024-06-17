using UsuariosApp.Domain.Interfaces.Messages;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Services;
using UsuariosApp.Infra.Data.Repositories;
using UsuariosApp.Infra.Messages.Producers;

namespace UsuariosApp.API.Configurations
{
    /// <summary>
    /// Classe de configuração para mapear as injeções de dependência do projeto
    /// </summary>
    public class DependencyInjectionConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            #region Adicionando as injeções de dependência do projeto

            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPerfilRepository, PerfilRepository>();
            services.AddTransient<IMessageProducer, MessageProducer>();

            #endregion
        }
    }
}
