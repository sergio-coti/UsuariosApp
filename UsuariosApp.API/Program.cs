using UsuariosApp.Domain.Interfaces.Messages;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Security;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Services;
using UsuariosApp.Infra.Data.Repositories;
using UsuariosApp.Infra.Messages.Consumers;
using UsuariosApp.Infra.Messages.Producers;
using UsuariosApp.Infra.Security.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuração para os endpoints da API ficarem com o texto em caixa baixa
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });

// Configurando a injeção de dependência de cada interface do projeto
// Associação de cada interface com a classe que a implementa
builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IMessageProducer, MessageProducer>();
builder.Services.AddTransient<IJwtTokenService, JwtTokenService>();

//registrar a classe consumer da mensageria
//builder.Services.AddHostedService<MessageConsumer>();

// Configuração para que o projeto Angular possa fazer requisições para a API
builder.Services.AddCors(
    config => config.AddPolicy("DefaultPolicy", builder => {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

//registrando a política do CORS
app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();

//tornando a classe Program pública (dar visibilidade
//para que outros projetos possam acessar esta classe)
public partial class Program { }
