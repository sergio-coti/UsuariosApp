using UsuariosApp.API.Configurations;
using UsuariosApp.Infra.Messages.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(config => { config.LowercaseUrls = true; });
SwaggerConfiguration.Configure(builder.Services);
DependencyInjectionConfiguration.Configure(builder.Services);
JwtConfiguration.Configure(builder.Services);
CorsConfiguration.Configure(builder.Services);
builder.Services.AddHostedService<MessageConsumer>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

CorsConfiguration.Use(app);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }
