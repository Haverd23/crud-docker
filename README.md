# Aplicação Full Stack com Docker

Este projeto é uma aplicação full stack construída com Docker para facilitar o desenvolvimento, a implantação e a execução de todos os componentes da aplicação de forma isolada e eficiente.

## 🚀 Tecnologias Usadas

- **Backend**: API em **.NET Core** (ASP.NET).
- **Frontend**: Aplicação em **Angular**.
- **Banco de Dados**: **SQL Server**.
- **Docker**

## 🎯 Objetivo Principal

A principal proposta deste projeto é demonstrar a utilização do Docker para orquestrar uma aplicação full stack.


## 💻 Como Rodar

### Pré-requisitos

Antes de rodar a aplicação, você precisará ter o Docker e o Docker Compose instalados em sua máquina. Se ainda não os tiver, você pode seguir as instruções de instalação:

- [Instalar Docker](https://docs.docker.com/get-docker/)
- [Instalar Docker Compose](https://docs.docker.com/compose/install/)

### Passos para Rodar a Aplicação

1. Clone o repositório:

   ```bash
   git clone https://github.com/Haverd23/crud-docker.git
   cd crud-docker
2. Execute o Compose:

   ```bash
   docker-compose up --build
3. Acesse a aplicação:
   - Backend - [http://localhost:7026/api/Pessoa](http://localhost:7026)
   - Frontend - [http://localhost:4200](http://localhost:4200)
