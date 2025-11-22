# Todo Backend 

API backend para gerenciamento de tarefas (Todo), permitindo criar, listar, atualizar e remover tarefas de forma simples.  
O objetivo é servir como base para estudos de desenvolvimento de APIs em .NET e para integração com um frontend (web).

## Tecnologias

- .NET (ASP.NET Web API)
- PostgreSQL
- C#

---

## Como rodar o projeto

### 1. Pré-requisitos

- .NET SDK compatível com o projeto  
  > Verifique a versão no arquivo `.csproj` (ex.: `net7.0`, `net8.0`, etc.)
- PostgreSQL instalado e em execução

### 2. Configuração do Banco

Antes de rodar, configure a conexão com seu banco de dados PostgreSQL:

1. Abra o arquivo `appsettings.json` (ou `appsettings.Development.json`).
2. Insira sua string de conexão na chave `ConnectionStrings`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=todo_db;Username=postgres;Password=sua_senha"
   }

### 3. Clonar o repositório

```bash
git clone https://github.com/jRodrigops/Todo.Backend.git

cd Todo.Backend
```

### 4. Rodar aplicação: 
# 1. Clonar o repositório
git clone [https://github.com/jRodrigops/Todo.Backend.git](https://github.com/jRodrigops/Todo.Backend.git)
cd Todo.Backend

# 2. Restaurar dependências
dotnet restore

# 3. Aplicar as Migrations (Criar o banco de dados)
dotnet ef database update

# 4. Rodar a aplicação
dotnet run
