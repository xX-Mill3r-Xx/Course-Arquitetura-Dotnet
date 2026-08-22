# Arquitetura de Aplicações .NET

> Repositório de estudos para projetar aplicações .NET organizadas em camadas, com separação clara de responsabilidades e foco em uma base sustentável para evolução.

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Sobre o projeto

Este repositório acompanha meu aprendizado sobre arquitetura de software no ecossistema .NET. O projeto reúne um **template de aplicação full stack** que demonstra como estruturar uma solução além do modelo tradicional de projeto único: API, interface web, regras de negócio, infraestrutura, contratos e testes possuem responsabilidades e projetos próprios.

O foco é exercitar decisões arquiteturais que tornam uma aplicação mais fácil de entender, testar e manter ao longo do tempo.

## Tecnologias

- **.NET 10**
- **ASP.NET Core Web API**
- **Blazor WebAssembly**
- **OpenAPI** para documentação da API em desenvolvimento
- **NUnit** e **coverlet** para testes e cobertura
- **StyleCop Analyzers** para padronização do código
- Localização em **português (Brasil)**, **inglês (EUA)** e **espanhol**

## Organização da solução

O código-fonte está em [`dotnet-template`](dotnet-template) e é organizado da seguinte forma:

```text
dotnet-template/
├── Backend/
│   ├── API/             # Host da API e controladores HTTP
│   ├── Contracts/       # Contratos e abstrações
│   ├── Models/          # Modelos de domínio e modelos gerais
│   ├── Services/        # Serviços e regras de aplicação
│   └── Infra/           # Integrações: IA, banco, e-mail e jobs
├── Frontend/
│   ├── API-Client/      # Comunicação do front-end com a API
│   ├── Framework/       # Componentes e recursos estruturais da UI
│   ├── Models/          # Modelos destinados à interface
│   └── Views/           # Aplicação Blazor, páginas e componentes
├── Global/              # Utilitários, recursos, exceções e DTOs compartilhados
└── Tests/               # Projetos de testes do back-end e front-end
```

## DTOs e contratos compartilhados

O projeto [`AppProject.Models`](dotnet-template/AppProject.Models) centraliza DTOs genéricos para padronizar a troca de dados entre as camadas da aplicação. Essa base evita a repetição de estruturas comuns em endpoints e serviços, mantendo os contratos consistentes.

### Interfaces base

| Interface | Responsabilidade |
| --- | --- |
| `IRequest` | Marca os objetos enviados para a aplicação. |
| `IResponse` | Marca os objetos retornados pela aplicação. |
| `IEntity` | Define entidades que podem expor `RowVersion` para controle de concorrência otimista. |
| `ISummary` | Marca projeções resumidas de dados. |

### DTOs de requisição

| DTO | Finalidade |
| --- | --- |
| `CreateOrUpdateRequest<TEntity>` | Encapsula a entidade utilizada nas operações de criação ou atualização. |
| `DeleteRequest<TIdType>` | Transporta o identificador do item a ser removido. |
| `GetByIdRequest<TIdType>` | Transporta o identificador para consulta de um item. |
| `GetByParentIdRequest<TIdType>` | Transporta o identificador de uma entidade pai para consultas relacionadas. |
| `SearchRequest` | Disponibiliza texto de busca e limite opcional de resultados (`Take`). |

### DTOs de resposta

| DTO | Finalidade |
| --- | --- |
| `EmptyResponse` | Representa uma resposta sem conteúdo específico. |
| `KeyResponse<TIdType>` | Retorna o identificador de um recurso. |
| `EntityResponse<TEntity>` | Retorna uma única entidade. |
| `EntitiesResponse<TEntity>` | Retorna uma coleção de entidades. |
| `SummaryResponse<TSummary>` | Retorna uma única projeção resumida. |
| `SummariesResponse<TSummary>` | Retorna uma coleção de projeções resumidas. |

### Princípios praticados

- **Separação de responsabilidades:** cada camada concentra um papel específico.
- **Baixo acoplamento:** contratos e projetos compartilhados reduzem dependências diretas entre componentes.
- **Evolução modular:** integrações externas ficam isoladas em projetos de infraestrutura.
- **Contratos consistentes:** DTOs genéricos padronizam as mensagens de entrada e saída da aplicação.
- **Qualidade contínua:** analisadores, testes automatizados e cobertura fazem parte da solução.
- **Preparação para internacionalização:** recursos da aplicação suportam múltiplas culturas.

## Como executar

### Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download)

### Restaurar e compilar

```bash
cd dotnet-template
dotnet restore AppProject.slnx
dotnet build AppProject.slnx
```

### Executar a API

```bash
dotnet run --project AppProject.Core.API
```

Em ambiente de desenvolvimento, a API expõe sua documentação OpenAPI. Consulte a URL informada pelo terminal ao iniciar a aplicação.

### Executar o front-end

Em outro terminal, dentro de `dotnet-template`:

```bash
dotnet run --project AppProject.Web
```

### Executar os testes

```bash
dotnet test AppProject.slnx
```

## Status

Este é um projeto de estudo em evolução. A estrutura representa o principal objeto de aprendizagem; novas implementações e integrações podem ser adicionadas progressivamente durante o curso.

## Licença

Distribuído sob a [Licença MIT](LICENSE). Veja o arquivo [`LICENSE`](LICENSE) para mais detalhes.
