using Microsoft.OpenApi.Models;

namespace UsuariosApp.API.Configurations
{
    /// <summary>
    /// Classe de configuração para o Swagger (documentação da API)
    /// </summary>
    public class SwaggerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "UsuariosApp - API para controle de usuários e permissões",
                    Description = "Treinamento C# WebDeveloper - COTI Informática",
                    Version = "1.0",
                    Contact = new OpenApiContact
                    {
                        Name = "COTI Informática",
                        Email = "contato@cotiinformatica.com.br",
                        Url = new Uri("http://www.cotiinformatica.com.br")
                    }
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Entre com o TOKEN JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[]{ }
                        }
                    });

            });
        }
    }
}
