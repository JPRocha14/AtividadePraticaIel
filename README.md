# Atividade Prática do IEL

Aplicação web em ASP.NET Core MVC para gerenciar estudantes do IEL.

## Funcionalidades
- Listar estudantes
- Adicionar novos estudantes
- Excluir estudantes

## Tecnologias Utilizadas
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap (estilização básica)

## Como Executar
1. Clone o repositório.
2. Configure a string de conexão no `appsettings.json`.
3. Execute:
   ```bash
   dotnet ef database update
   dotnet run
