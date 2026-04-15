# Gerenciador Financeiro - C# Console

Este é um projeto de gestão financeira simples, mas construído com um propósito real: consolidar meu aprendizado em Programação Orientada a Objetos (POO) e manipulação moderna de dados com C#.

## 💡 Sobre o projeto
Diferente de muitos projetos que vemos por aí, este código foi **escrito 100% no braço**. Não utilizei ferramentas de auto-complete de IA ou geradores de código. Cada classe, loop de validação (`TryParse`), tratamento de exceção (`try-catch`) e lógica de consulta com LINQ foi pensada e digitada manualmente para garantir o domínio total da linguagem C#.

O foco aqui foi entender como os dados fluem entre as classes e como criar uma interface de terminal que seja robusta, resiliente e que não quebre com entradas inválidas do usuário.

## 🚀 O que ele faz
- **Registro de Transações:** Cadastro manual de entradas (Depósitos) e saídas (Retiradas) com validação em tempo real.
- **ID Gerencial:** Sistema automático que numera e identifica cada transação de forma única.
- **Extrato Filtrado:** Sistema de busca que permite visualizar apenas entradas, saídas ou o histórico completo usando LINQ.
- **Balanço Inteligente:** O sistema processa os diferentes tipos de transação e entrega o saldo real atualizado.
- **Blindagem de Erros (Resiliência):** Tratamento rigoroso de entradas de teclado com `try-catch` e loops de validação para evitar que o programa feche por erro de digitação.

## 🛠️ Tecnologias e Ferramentas
- **Linguagem:** C# (.NET 10.0)
- **Recursos:** LINQ (Language Integrated Query) para filtros e cálculos.
- **Editor:** VSCodium (Open Source)
- **Sistema Operacional:** CachyOS (Linux)

## 🧠 O que eu aprendi
- **Estruturação de classes e objetos (POO):** Divisão clara entre modelos de dados e lógica de gerenciamento.
- **Consultas com LINQ:** Uso de `.Where()`, `.Sum()` e `.Any()` para processar listas de forma limpa e performática.
- **Tratamento de Exceções:** Implementação de `try-catch` para capturar erros inesperados e manter a aplicação rodando.
- **Validação de Inputs:** Uso estratégico de `TryParse` para sanitizar dados antes que eles cheguem à lógica de negócio.
- **Refinamento de UX no Console:** Criação de loops independentes para uma navegação fluida e sem frustrações para o usuário.

---
Desenvolvido com foco e persistência por [D4RL1NG0].