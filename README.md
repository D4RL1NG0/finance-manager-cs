# Finance API - Gerenciador Financeiro

API para gerenciamento de transações financeiras (depósitos e retiradas), com foco em **regras de negócio**, **consistência de dados** e **boas práticas de back-end**.

---

## Sobre o projeto

Este é um projeto pessoal desenvolvido para simular um sistema real de gerenciamento financeiro, aplicando conceitos como:

* separação de responsabilidades
* validação de regras de negócio
* persistência de dados
* controle de consistência com transações

---

## Funcionalidades

* Registro de transações (depósitos e retiradas)
* Remoção de transações
* Atualização de transações
* Listagem de transações (entrada, saída ou todas)
* Cálculo de saldo em tempo real

---

## Regras de negócio

A API garante integridade dos dados através de:

* validação de valores (não permite zero ou negativos)
* bloqueio de retiradas com saldo insuficiente
* uso de **transações no banco de dados** para garantir consistência
* tratamento de erros com mensagens claras

---

## Tecnologias

* C#
* .NET / ASP.NET Core (Web API)
* Entity Framework Core
* SQLite

---

## Estrutura

* **Controllers**: responsáveis pela comunicação HTTP
* **Services (Manager)**: onde está a lógica de negócio
* **Data**: configuração do banco e contexto

---

## O que foi praticado

* construção de APIs REST
* aplicação de regras de negócio no back-end
* uso de Entity Framework Core
* controle de consistência com transações
* tratamento de erros com try/catch

---

## Observações

Este projeto foca exclusivamente no **back-end**, priorizando organização, clareza e consistência das regras de negócio.

---

## Autor

Desenvolvido por D4RL1NG0
