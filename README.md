# UsuariosApp

O **UsuariosApp** é uma API desenvolvida para gerenciar autenticação e controle de acesso de usuários. Este projeto utiliza diversas tecnologias e padrões de design para garantir a escalabilidade, segurança e confiabilidade.

## Tecnologias Utilizadas

- **ASP.NET API 8**: Framework para construção de APIs RESTful robustas e escaláveis com suporte a várias funcionalidades, como controle de rotas e injeção de dependências.  
  [Documentação do ASP.NET Core](https://learn.microsoft.com/aspnet/core)

- **Entity Framework Core - Code First**: Utilizado para mapear objetos do C# para o banco de dados relacional, permitindo que o esquema do banco de dados seja gerado diretamente do código.  
  [Documentação do Entity Framework Core](https://learn.microsoft.com/ef/core/)

- **RabbitMQ**: Sistema de mensageria utilizado para enviar e receber mensagens de forma assíncrona entre sistemas, garantindo escalabilidade e desacoplamento entre serviços.  
  [Documentação do RabbitMQ](https://www.rabbitmq.com/documentation.html)

- **MongoDB (NoSQL)**: Banco de dados NoSQL utilizado para armazenar dados de forma flexível e escalável, sem a necessidade de um esquema fixo, ideal para grandes volumes de dados.  
  [Documentação do MongoDB](https://www.mongodb.com/docs/)

- **JWT (JSON Web Token)**: Utilizado para autenticação segura e baseada em tokens, permitindo que a API valide a identidade do usuário de forma eficiente e escalável.  
  [Documentação do JWT](https://jwt.io/introduction)

- **xUnit**: Framework de testes unitários utilizado para garantir a qualidade e a corretude do código através da execução de testes automatizados.  
  [Documentação do xUnit](https://xunit.net/)

## Padrões Aplicados

- **DDD (Domain Driven Design)**: Este padrão de design organiza o código em torno do domínio da aplicação, separando as preocupações em camadas (como Domínio, Aplicação, Infraestrutura) e focando na lógica de negócio. O DDD busca alinhar o código com o entendimento do negócio para que a aplicação seja fácil de manter e evoluir.

- **TDD (Test Driven Development)**: Seguindo o ciclo de "Red-Green-Refactor", o TDD foca na criação de testes antes do desenvolvimento do código funcional. Isso ajuda a garantir que o código funcione conforme o esperado e que seja desenvolvido com foco em qualidade e requisitos claros.

## Estrutura do Projeto

O projeto segue a arquitetura de camadas, com as seguintes divisões:

- **Domain**: Contém as entidades, interfaces e regras de negócio.
- **Application**: Contém a lógica de aplicação e os serviços que fazem a intermediação entre o domínio e a infraestrutura.
- **Infrastructure**: Contém as implementações de banco de dados, mensageria e outros serviços externos.
- **Tests**: Implementações de testes automatizados utilizando o framework xUnit, para garantir a qualidade do código.

## Requisitos

- .NET 8 SDK ou superior
- MongoDB instalado ou serviço em nuvem (MongoDB Atlas)
- RabbitMQ instalado ou instância em nuvem
- Visual Studio 2022 ou outro editor de código compatível

## Documentação e Testes

- A API está documentada utilizando o Swagger e pode ser acessada em `http://localhost:{porta}/swagger`.
- Os testes podem ser executados através do Visual Studio ou pela linha de comando:
    ```bash
    dotnet test
    ```

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

## Licença

Este projeto está licenciado sob os termos da [MIT License](LICENSE).
