# 💰 Finance Pro - Full Stack Financial Manager

Este é um projeto de gestão financeira que evoluiu de uma aplicação Console para uma **Web API robusta** com um **Front-end moderno e responsivo**. O projeto consolida aprendizado em Programação Orientada a Objetos (POO), persistência de dados real e integração completa entre Back-end e Front-end.

## 💡 Sobre o projeto
O núcleo deste sistema (Back-end) foi desenvolvido **100% manualmente**, focado em entender a arquitetura de uma API real. Para dar vida a esses dados, utilizei assistência de IA para a construção da interface, focando o meu aprendizado na **lógica de integração**: como fazer o JavaScript "conversar" corretamente com o meu código em C#.

## 🚀 O que ele faz
- **Interface Estilo App:** Front-end limpo com temática "Fintech", incluindo modo Timeline para transações.
- **Arquitetura Web API:** Exposição de recursos via HTTP (GET, POST, DELETE) para manipulação de finanças.
- **Registro Persistente:** Cadastro de entradas (Depósitos) e saídas (Retiradas) em banco de dados SQLite.
- **Remoção de Transações:** Exclusão de registros diretamente pela interface com atualização em tempo real.
- **Lógica de Negócio Real:** O sistema impede saques maiores que o saldo disponível e valida valores, retornando erros claros via JSON.
- **Timeline Inteligente:** Exibição das transações mais recentes no topo, com ícones e cores dinâmicas.
- **Integração Assíncrona:** Uso de `fetch` e `async/await` para comunicação em tempo real com o servidor.

## 🛠️ Tecnologias e Ferramentas
### **Back-end (Foco do Estudo)**
- **Linguagem:** C# (.NET Core)
- **Framework:** ASP.NET Core (Web API)
- **ORM:** Entity Framework Core (EF Core)
- **Banco de Dados:** SQLite (DB)

### **Front-end (Desenvolvido com assistência de IA)**
- **Linguagem:** JavaScript (Vanilla JS), HTML5 e CSS3.

### **Ambiente**
- **Editor:** VS Code / VSCodium
- **Sistema Operacional:** CachyOS (Linux)

## 🧠 O que eu aprendi neste projeto
- **Arquitetura em Camadas:** Separação de responsabilidades entre Controller (comunicação) e Manager (lógica de negócio).
- **Integração Full Stack:** Como conectar o Front-end ao Back-end garantindo que ambos falem a mesma "língua" (JSON).
- **Consumo de APIs:** Entendi a lógica de como enviar e receber pacotes de dados via protocolo HTTP e lidar com rotas.
- **Tratamento de Erros:** Uso de `try/catch` e `throw` para validar regras (como saldo insuficiente ou ID inexistente).
- **Mapeamento de Dados:** Como traduzir as ações da interface (cliques em botões) para as regras definidas no C#.
- **Versionamento com Git:** Organização de um repositório que contém tanto o código do servidor quanto os arquivos do cliente.

## 🤖 Nota sobre o Front-end
A interface visual, o CSS e a estrutura base do JavaScript foram gerados com auxílio de **Inteligência Artificial (Gemini)**. O objetivo dessa escolha foi focar meus esforços no aprendizado de **C# e ASP.NET Core**, utilizando a IA para acelerar a criação de uma interface funcional que permitisse testar a API em um cenário real de uso.

---
Desenvolvido com foco e imersão por **D4RL1NG0**. 🚀