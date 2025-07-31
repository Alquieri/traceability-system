# Sistema de Rastreabilidade de Peças 🏭

![Status](https://img.shields.io/badge/status-concluído-green) ![.NET](https://img.shields.io/badge/.NET-8-blueviolet) ![Angular](https://img.shields.io/badge/Angular-17-red)  



> Status do Projeto: Concluído ✔️

## 📝 Descrição

Este projeto é um sistema full-stack para a rastreabilidade de peças industriais, desenvolvido para controlar o cadastro, a movimentação entre estações de processo, o histórico completo e a validação do fluxo de produção.

---

## ✨ Funcionalidades

- **API RESTful:** Back-end robusto desenvolvido em .NET para gerenciar todas as regras de negócio.
- **Interface Web:** Front-end funcional e reativo desenvolvido com Angular.
- **Gestão de Peças e Estações:** CRUD completo para o cadastro de peças e das estações de processo.
- **Controle de Fluxo:** Validação estrita da ordem de processo, garantindo que as peças sigam o fluxo obrigatório (Recebimento -> Montagem -> Inspeção Final).
- **Rastreabilidade Completa:** Registro de todo o histórico de movimentações por peça, incluindo origem, destino, data e responsável.
- **Testes Unitários:** O back-end possui uma suíte de testes unitários com xUnit para garantir a integridade das regras de negócio.
- **Documentação de API:** A API é autodocumentada utilizando Swagger/OpenAPI para facilitar o uso e os testes.

---

## 🛠️ Tecnologias Utilizadas

### Back-end:
- .NET 8
- ASP.NET Core Web API
- xUnit (para testes unitários)
- Moq (para mocking)


### Front-end:
- Angular 20
- TypeScript
- HTML5 / CSS3

### Ferramentas:
- Git & GitHub
- Swagger / OpenAPI

---

## 🚀 Como Rodar o Projeto

### Pré-requisitos:
- .NET SDK
- Node.js (que inclui o npm)
- Angular CLI

### 1. Clone o repositório:
```bash
git clone https://github.com/Alquieri/traceability-system.git
cd traceability-system
```
### 2. Rode o Back-end (API)

```bash
# Navegue até a pasta do back-end
cd backend

# Restaure as dependências e inicie o servidor
dotnet run
```
### 3. Rode o Front-end (API)

```bash
# Abra um NOVO terminal e navegue até a pasta do front-end
cd frontend

# Instale as dependências (apenas na primeira vez)
npm install

# Inicie o servidor de desenvolvimento
ng serve --open
```
### A aplicação estará acessível em http://localhost:4200.
---


👨‍💻 Autor
Guilherme Alquieri
