using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UsuariosApp.WEB;
using UsuariosApp.WEB.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient 
    { 
        //Define o endereço para acesso da API
        BaseAddress = new Uri("http://localhost:5114") 
    });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddTransient<AuthService>();

await builder.Build().RunAsync();
