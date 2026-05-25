# VendinhaAPI

Sistema de gerenciamento de clientes, dívidas e pagamentos desenvolvido em ASP.NET Core Web API utilizando SQLite e Entity Framework Core.

---

# Sobre o Projeto

A proposta do projeto é fornecer uma API REST para gerenciamento de:

- Clientes
- Dívidas
- Pagamentos
- Relatórios financeiros

O sistema foi desenvolvido com foco acadêmico, priorizando:

- organização de código
- separação de responsabilidades
- arquitetura simples
- implementação objetiva das regras de negócio
- persistência de dados utilizando SQLite

A API também conta com integração com Swagger para documentação e testes dos endpoints.

---

# Tecnologias Utilizadas

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- Dependency Injection
- DTO Pattern

---

# Arquitetura do Projeto

O projeto segue uma arquitetura simples em camadas:

```text
Controllers
↓
Services
↓
Entity Framework Core
↓
SQLite
```

Estrutura das pastas:

```text
VendinhaAPI/
│
├── Controllers/
├── DTOs/
├── Data/
├── Models/
├── Services/
├── Migrations/
├── Program.cs
├── VendinhaAPI.csproj
└── vendinha.db
```

---

# Funcionalidades

## Clientes

- Cadastro de clientes
- Busca de cliente por ID
- Listagem de clientes
- Exclusão de clientes
- Validação de CPF duplicado
- Validação de e-mail
- Cálculo automático de idade

## Dívidas

- Abertura de dívida
- Listagem de dívidas
- Busca de dívidas por cliente
- Controle de status da dívida
- Bloqueio de múltiplas dívidas pendentes

## Pagamentos

- Registro de pagamento
- Atualização automática do status da dívida
- Registro da data de pagamento
- Bloqueio de pagamento duplicado

## Relatórios

- Relatório de contas abertas
- Relatório de clientes inadimplentes
- Relatório de total recebido

---

# Regras de Negócio

## CPF único

O sistema não permite cadastrar dois clientes com o mesmo CPF.

## Apenas uma dívida pendente por cliente

Cada cliente pode possuir apenas uma dívida com status `Pendente`.

## Idade calculada automaticamente

A idade é calculada dinamicamente a partir da data de nascimento do cliente.

## Controle de pagamentos

Ao registrar um pagamento:

- a dívida recebe status `Pago`
- a data de pagamento é registrada
- pagamentos duplicados são bloqueados

---

# Banco de Dados

O projeto utiliza SQLite para persistência local dos dados.

Banco utilizado:

```text
vendinha.db
```

A persistência é feita utilizando:

- Entity Framework Core
- DbContext
- Migrations

## Entidade Cliente

```text
Id
NomeCompleto
CPF
DataNascimento
Email
Idade
```

## Entidade Divida

```text
Id
ClienteId
Valor
Situacao
DataCriacao
DataPagamento
```

---

# Endpoints da API

# Clientes

## Listar clientes

```http
GET /clientes
```

## Buscar cliente por ID

```http
GET /clientes/{id}
```

## Criar cliente

```http
POST /clientes
```

## Atualizar cliente

```http
PUT /clientes/{id}
```

## Deletar cliente

```http
DELETE /clientes/{id}
```

---

# Dívidas

## Listar dívidas

```http
GET /dividas
```

## Buscar dívidas por cliente

```http
GET /dividas/cliente/{clienteId}
```

## Criar dívida

```http
POST /dividas
```

## Registrar pagamento

```http
PUT /dividas/{id}/pagar
```

---

# Relatórios

## Contas abertas

```http
GET /relatorios/contas-abertas
```

## Clientes inadimplentes

```http
GET /relatorios/inadimplentes
```

## Total recebido

```http
GET /relatorios/total-recebidos
```

---

# DTOs Utilizados

O projeto utiliza DTOs para separação de entrada e saída de dados.

DTOs implementados:

```text
CreateClienteDto
UpdateClienteDto
ClienteResponseDto
CreateDividaDto
PagamentoDto
ClienteComDividaDto
```

---

# Estrutura dos Services

## ClienteService

Responsável por:

- cadastro de clientes
- validações
- busca
- listagem
- remoção

## ContaService

Responsável por:

- abertura de dívidas
- validação de dívida pendente
- relatórios
- cálculos financeiros

## PagamentoService

Responsável por:

- registro de pagamentos
- atualização do status da dívida
- controle de pagamentos duplicados

---

# Como Executar o Projeto

## Pré-requisitos

- .NET SDK 10
- Git

---

## Clonar o repositório

```bash
git clone <url-do-repositorio>
```

---

## Entrar na pasta do projeto

```bash
cd VendinhaAPI
```

---

## Restaurar dependências

```bash
dotnet restore
```

---

## Executar as migrations

```bash
dotnet ef database update
```

---

## Executar a API

```bash
dotnet run
```

---

# Swagger

Após executar o projeto, o Swagger ficará disponível em:

```text
https://localhost:xxxx/swagger
```

O Swagger permite:

- visualizar endpoints
- testar requisições
- validar respostas
- testar regras de negócio

---

# Pacotes Utilizados

```xml
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Sqlite
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore
Microsoft.AspNetCore.OpenApi
```

---

# Objetivo Acadêmico

Este projeto foi desenvolvido com o objetivo de praticar:

- desenvolvimento de APIs REST
- Entity Framework Core
- persistência com SQLite
- arquitetura em camadas
- organização de serviços e controllers
- boas práticas em ASP.NET Core

---

# Autores

Projeto desenvolvido para fins acadêmicos.

Integrantes:

- Arthur Souza
- Cesar Algusto

---

# Licença

Este projeto possui finalidade educacional.
