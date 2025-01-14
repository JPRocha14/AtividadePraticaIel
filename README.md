# 🌐 Atividade Prática do IEL

Aplicação web em **ASP.NET Core MVC** para gerenciar estudantes do **IEL**.

## Funcionalidades 📋
- 📜 Listar estudantes
- ➕ Adicionar novos estudantes
- 🗑️ Excluir estudantes
- 🔍 Pesquisar estudantes por nome, CPF ou data de conclusão

## Tecnologias Utilizadas 🛠️
- **ASP.NET Core MVC** - Framework para desenvolvimento da aplicação web.
- **Entity Framework Core** - ORM utilizado para interação com o banco de dados.
- **SQL Server** - Banco de dados utilizado.
- **Bootstrap** - Framework CSS para estilização básica e responsiva.

## Como Executar 🚀
1. Clone o repositório:
   ```bash
   git clone <url-do-repositório>
2. Configure a string de conexão no arquivo appsettings.json.
3. Execute os seguintes comandos para configurar o banco de dados e iniciar a aplicação:
   dotnet ef database update
   dotnet run