# UsuariosApp

## Descrição

UsuariosApp é um projeto de API desenvolvido com ASP.NET Core (versão .NET 8), utilizando Entity Framework para a manipulação do banco de dados, XUnit para testes de integração e JWT para autenticação e autorização. Além disso, o frontend da aplicação foi desenvolvido utilizando Blazor, um framework da Microsoft para construção de interfaces web dinâmicas.

## Tecnologias Utilizadas

- **ASP.NET Core (NET 8)**: Framework principal para a construção da API.
- **Entity Framework Core**: ORM (Object-Relational Mapper) utilizado para interagir com o banco de dados.
- **XUnit**: Framework de testes utilizado para escrever e executar testes de integração.
- **JWT (JSON Web Tokens)**: Implementação de autenticação e autorização baseada em tokens.
- **Blazor**: Framework utilizado para o desenvolvimento do frontend da aplicação.

## Frontend em Blazor

O frontend do UsuariosApp foi construído utilizando o **Blazor**, um framework que permite a criação de interfaces web interativas e dinâmicas utilizando C#. 

### Principais características do Blazor no projeto:

- **C# no Frontend**: Permite o uso de C# ao invés de JavaScript para desenvolvimento de componentes e lógica de interface, promovendo uma consistência entre backend e frontend.
- **Componentização**: A interface é composta por componentes reutilizáveis, tornando a manutenção e expansão do projeto mais fáceis.
- **Integração com a API**: O frontend se comunica diretamente com a API **UsuariosApp** para realizar operações como autenticação (login) e gerenciamento de usuários, utilizando **JWT** para garantir a segurança nas requisições.
- **Blazor WebAssembly**: Utilizado para a execução do frontend diretamente no navegador do usuário, proporcionando uma experiência interativa e responsiva.

## Configuração do Projeto

### Requisitos

- .NET 8 SDK
- SQL Server ou outro banco de dados compatível com Entity Framework Core
- Visual Studio ou Visual Studio Code

### Requisitos adicionais para o frontend:

- **Blazor WebAssembly** configurado e rodando no Visual Studio ou Visual Studio Code
