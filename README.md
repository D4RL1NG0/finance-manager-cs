# Gerenciador Financeiro - ASP.NET Core Web API + Entity Framework

Este é um projeto de gestão financeira que evoluiu de uma aplicação Console para uma **Web API robusta**. Construído com o propósito de consolidar aprendizado em Programação Orientada a Objetos (POO), arquitetura de APIs modernas e persistência de dados real.

## 💡 Sobre o projeto
Este código foi **escrito 100% no braço**. Cada classe, a lógica de persistência com **Entity Framework Core**, e agora a exposição de dados via **EndPoints (API)**, foi pensada e digitada manualmente. 

O foco saiu do simples terminal e agora utiliza o padrão de mercado para sistemas distribuídos: uma API que pode servir um site, um aplicativo ou qualquer outro sistema.

## 🚀 O que ele faz
- **Arquitetura Web API:** Exposição de recursos via HTTP (GET, POST) para manipulação de finanças.
- **Registro de Transações Persistente:** Cadastro de entradas (Depósitos) e saídas (Retiradas) em banco de dados SQLite.
- **Tratamento de Exceções Reais:** O sistema impede saques maiores que o saldo disponível e valores negativos, retornando erros HTTP apropriados (400 Bad Request).
- **ID Automático (Banco de Dados):** Chaves primárias gerenciadas pelo motor do banco.
- **Cálculo de Balanço no Back-end:** A lógica de saldo é processada pelo servidor, garantindo a integridade dos dados.
- **Persistência de Dados:** Uso de SQLite para garantir que os dados sobrevivam a reinicializações do servidor.

## 🛠️ Tecnologias e Ferramentas
- **Linguagem:** C# (.NET 10.0)
- **Framework:** ASP.NET Core (Web API)
- **ORM:** Entity Framework Core (EF Core)
- **Banco de Dados:** SQLite
- **Ferramentas de Teste:** cURL / Postman / Navegador
- **Editor:** VS Code / VSCodium
- **Sistema Operacional:** CachyOS (Linux)

## 🧠 O que eu aprendi até agora
- **Migração de Arquitetura:** Como transformar um código de lógica pura (Console) em um serviço acessível via Web (API).
- **Controllers e Roteamento:** Entendi como o ASP.NET recebe uma requisição na URL e decide qual parte do código deve responder.
- **Tratamento de Erros Profissional:** Uso de `try/catch` e `throw new` para disparar erros de negócio e transformá-los em respostas JSON claras para o usuário.
- **Injeção de Dependência:** Como conectar o Banco de Dados e os Gerentes de Lógica (Managers) dentro do ecossistema do ASP.NET.
- **CORS & Segurança:** Entendendo como liberar (ou bloquear) o acesso de diferentes Front-ends à minha API.
- **Versionamento com Git:** Gerenciamento de histórico, uso de `.gitignore` para manter o projeto limpo e documentação de evolução.

---
Desenvolvido com foco e imersão por [D4RL1NG0]. 🚀