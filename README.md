# Gerenciador Financeiro - C# Console + Entity Framework

Este é um projeto de gestão financeira simples, mas construído com um propósito real: consolidar meu aprendizado em Programação Orientada a Objetos (POO), persistência de dados e manipulação moderna de sistemas com C#.

## 💡 Sobre o projeto
Diferente de muitos projetos que vemos por aí, este código foi **escrito 100% no braço**. Cada classe, lógica de persistência com **Entity Framework Core**, configuração de Banco de Dados e consultas complexas com LINQ foi pensada e digitada manualmente. 

O foco aqui não foi apenas fazer funcionar, mas entender a "mágica" por trás do ORM, como as migrations transformam código C# em tabelas SQL e como manter um sistema resiliente mesmo após ser fechado.

## 🚀 O que ele faz
- **Registro de Transações Persistente:** Cadastro de entradas (Depósitos) e saídas (Retiradas) que ficam salvas em um banco de dados SQLite.
- **ID Automático (Banco de Dados):** Sistema de chave primária gerenciado pelo motor do banco, garantindo que cada transação tenha uma identidade única eterna.
- **Extrato com LINQ & SQL:** Sistema de busca que filtra os dados diretamente no banco de dados, otimizando performance.
- **Balanço Real:** O sistema processa o histórico total salvo no disco e entrega o saldo real atualizado.
- **Persistência de Dados:** Você pode fechar o programa, desligar o computador e, ao voltar, seus dados estarão exatamente onde você os deixou.

## 🛠️ Tecnologias e Ferramentas
- **Linguagem:** C# (.NET 10.0)
- **ORM:** Entity Framework Core (EF Core)
- **Banco de Dados:** SQLite
- **Recursos:** LINQ para filtros e cálculos, Migrations para versionamento do banco.
- **Editor:** VSCodium (Open Source)
- **Sistema Operacional:** CachyOS (Linux)

## 🧠 O que eu aprendi
- **Persistência de Dados com EF Core:** Saí das listas temporárias (`List<T>`) para o armazenamento permanente em arquivos `.db`.
- **Arquitetura de Banco de Dados:** Entendi como mapear classes C# para tabelas usando `DbContext` e `DbSet`.
- **Migrations:** Aprendi a versionar a estrutura do banco de dados através do terminal (`dotnet ef`).
- **Consultas Otimizadas:** Uso de `.AsQueryable()` e `.ToList()` para entender quando os dados estão sendo filtrados no banco e quando estão vindo para a memória.
- **Gerenciamento de Recursos (Using):** Implementação do padrão `using` para garantir que as conexões com o banco de dados sejam abertas e fechadas corretamente, evitando vazamento de memória.
- **Resiliência de Sistema:** Como o código se comporta quando a lógica de negócio precisa se comunicar com um serviço externo (o Banco).

---
Desenvolvido com foco, persistência e muitas horas de imersão por [D4RL1NG0].