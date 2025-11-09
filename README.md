Backend oficial do sistema de reservas de restaurante.  
Desenvolvido com **ASP.NET Core 8**, **Entity Framework Core**, **SQL Server LocalDB** e **JWT Authentication**.

---

## Sobre o projeto

O **Restaurant App Backend** é a API responsável por gerenciar o sistema de autenticação, usuários e reservas do aplicativo de restaurante.  
Ele fornece endpoints REST para:

- Autenticação de usuários e administradores (via JWT)
- Gerenciamento de usuários
- Registro e consulta de reservas
- Dashboard administrativo de reservas

---

## Arquitetura

A aplicação segue o padrão **Clean Architecture simplificado**, dividida em camadas:

- **Controllers** → Pontos de entrada da API (REST endpoints)
- **Services** → Regras de negócio (ex: geração de token JWT)
- **Data** → Contexto do banco de dados (Entity Framework Core)
- **Models** → Representação das entidades (ex: User)

---

## Tecnologias utilizadas

| Categoria | Ferramenta |
|------------|-------------|
| Linguagem | C# (.NET 8) |
| Framework | ASP.NET Core Web API |
| ORM | Entity Framework Core |
| Banco de Dados | SQL Server (LocalDB) |
| Autenticação | JWT (JSON Web Token) |
| Segurança | Hash de senha (SHA256) |
| Ambiente | Visual Studio Code |
| Versionamento | Git + GitHub |

---

## Autenticação JWT

A autenticação do sistema é feita por JWT (JSON Web Token).
Cada login válido retorna um token que deve ser usado em requisições autenticadas.

Configuração em appsettings.json:

````json
"Jwt": {
  "Key": "sua_chave_super_secreta_aqui_1234567890",
  "Issuer": "RestaurantAPI",
  "Audience": "RestaurantAPIUsers",
  "ExpireMinutes": 120
}
````

**Estrutura do Token**:
O token contém as seguintes claims:
- sub: Email do usuário autenticado
- role: Papel do usuário (Admin ou User)
- jti: ID único do token

**Estrutura do Token**:
````bash
RestaurantAPI/
 ├── Controllers/                   # Controle de todas funções do sistema
 │    └── AuthController.cs         
 ├── Data/
 │    └── RestaurantContext.cs      # Contexto EF Core
 ├── Models/
 │    └── User.cs                   # Entidade User
 ├── Services/
 │    └── TokenService.cs           # Geração do JWT
 ├── appsettings.json               # Configurações do projeto
 ├── Program.cs                     # Configuração do pipeline da aplicação
 └── RestaurantAPI.csproj           # Arquivo do projeto

````

## Autor
**Lucas Fernandes**
Desenvolvedor Full Stack | React • React Native • Node.js • ASP.NET
- lucaspedrofernandes@gmail.com