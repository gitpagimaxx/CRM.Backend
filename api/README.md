# 🚀 CRM Backend API

API REST moderna para gerenciamento de relacionamento com clientes (CRM) construída com .NET 10, seguindo os princípios de Clean Architecture, CQRS e Event Sourcing.

## 📋 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Tecnologias](#tecnologias)
- [Arquitetura](#arquitetura)
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Configuração](#configuração)
- [Executando o Projeto](#executando-o-projeto)
- [Endpoints da API](#endpoints-da-api)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Boas Práticas](#boas-práticas)

## 🎯 Sobre o Projeto

Sistema de CRM backend que oferece funcionalidades para gerenciamento de clientes com suporte a:

- ✅ Autenticação JWT
- ✅ Event Sourcing para rastreabilidade completa
- ✅ CQRS (Command Query Responsibility Segregation)
- ✅ Integração com API ViaCEP para consulta de endereços
- ✅ Logs estruturados com Serilog
- ✅ PostgreSQL como banco de dados

## 🛠 Tecnologias

- **.NET 10** - Framework principal
- **PostgreSQL** - Banco de dados relacional
- **Dapper** - Micro ORM para queries de leitura
- **MediatR** - Implementação de CQRS e Mediator Pattern
- **Serilog** - Logging estruturado
- **JWT Bearer** - Autenticação e autorização
- **Polly** - Resiliência (retry, timeout)
- **Swagger/OpenAPI** - Documentação da API

## 🏗 Arquitetura

O projeto segue **Clean Architecture** com separação em camadas:

### Padrões Implementados

- **CQRS**: Separação entre comandos (write) e queries (read)
- **Event Sourcing**: Histórico completo de eventos de domínio
- **Repository Pattern**: Abstração da camada de dados
- **Mediator Pattern**: Desacoplamento entre componentes
- **Dependency Injection**: Inversão de controle

## 📦 Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [PostgreSQL 14+](https://www.postgresql.org/download/)
- [Visual Studio 2026](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

## ✨ Boas Práticas

### Desenvolvimento

- ✅ Código segue princípios SOLID
- ✅ Testes unitários com xUnit
- ✅ Validações com FluentValidation
- ✅ Resiliência com Polly (retry, timeout)
- ✅ Logs estruturados para observabilidade

### Segurança

- ✅ Autenticação JWT Bearer
- ✅ Validação de tokens
- ✅ Hashing de senhas
- ✅ Connection strings via variáveis de ambiente em produção

### Performance

- ✅ Dapper para queries otimizadas
- ✅ Paginação em listagens
- ✅ Async/await em toda a stack
- ✅ Connection pooling do PostgreSQL

## 🔧 Instalação

1. **Clone o repositório**

``` shell
git clone https://github.com/gitpagimaxx/crm-source.git 
cd crm-source/api
```

A API estará disponível em:
- HTTP: `http://localhost:7148`
- HTTPS: `https://localhost:7148`
- Swagger: `https://localhost:7148/swagger`

## 📡 Endpoints da API

### Autenticação

| Método | Endpoint | Descrição | Auth |
|--------|----------|-----------|------|
| POST | `/api/auth/login` | Efetua login | ❌ |
| POST | `/api/auth/register` | Registra novo usuário | ❌ |

### Clientes

| Método | Endpoint | Descrição | Auth |
|--------|----------|-----------|------|
| GET | `/api/customers` | Lista clientes (paginado) | ✅ |
| GET | `/api/customers/{id}` | Busca cliente por ID | ✅ |
| POST | `/api/customers` | Cria novo cliente | ✅ |
| PUT | `/api/customers/{id}` | Atualiza cliente | ✅ |
| GET | `/api/customers/{id}/events` | Histórico de eventos | ✅ |
| GET | `/api/customers/check-document` | Valida unicidade de documento | ✅ |

### Exemplo de Request

**POST** `/api/customers`

```
{ "name": "João Silva", "document": "12345678900", "email": "joao@example.com", "companyName": "Empresa XYZ", "stateRegistration": "123456789", "zipCode": "01310-100", "addressNumber": "1000", "addressComplement": "Sala 10" }
```

## 📁 Estrutura do Projeto

```
api/
└── src/
    ├── CRM.Backend.Api/                # Camada de apresentação
    │   ├── Endpoints/                  # Minimal APIs endpoints
    │   ├── Middleware/                 # Middlewares customizados
    │   └── Program.cs                  # Entry point
    │
    ├── CRM.Backend.Application/        # Casos de uso (Application Layer)
    │   ├── Commands/                   # Comandos (Write/Escrita - CQRS)
    │   ├── Queries/                    # Consultas (Read/Leitura - CQRS)
    │   ├── Interfaces/                 # Contratos (Abstrações)
    │   └── Common/                     # DTOs e helpers
    │
    ├── CRM.Backend.Domain/             # Núcleo da lógica de negócio
    │   ├── Aggregates/                 # Entidades e agregados
    │   ├── Events/                     # Eventos de domínio
    │   ├── Interfaces/                 # Contratos do domínio (ex: Repositórios)
    │   └── ValueObjects/               # Objetos de valor
    │
    └── CRM.Backend.Infra/              # Detalhes de implementação e ferramentas
        ├── Persistence/                # Repositórios e Contexto do DB
        ├── Auth/                       # Autenticação e Autorização
        ├── ExternalServices/           # Integrações com APIs externas
        └── Projection/                 # Projeções de eventos (Read Models)
└── tests/                              # Testes automatizados (Unitários, Integração)

```

